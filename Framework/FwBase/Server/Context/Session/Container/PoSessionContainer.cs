using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ProjectOne
{
    public partial class PoSessionContainer
    {
        private const string RootUrlApp = "/App";
        private const string RootUrlDesktop = "/Desktop";

        private readonly ConcurrentDictionary<string, PoUITaskbar> _sessionTaskbar;
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, PoUIComponent>> _sessionPages;

        private PoSessionContainer()
        {
            _sessionTaskbar = new ConcurrentDictionary<string, PoUITaskbar>();
            _sessionPages = new ConcurrentDictionary<string, ConcurrentDictionary<string, PoUIComponent>>();
        }

        public void ProcessRequest(PoHttpContext context, PoHttpSession session)
        {
            var pageKey = CreatePageKey(context.Request);
            if (RedirectToDesktop_IfInvalidPath(context, pageKey)) return;
            if (CreateSession_IfNotExists(context, session.ID, pageKey)) return;
            if (CreatePageInSession_IfPageNotExists(context, session.ID, pageKey)) return;
            ResponseRequest(context, session, pageKey);
        }

        private void ResponseRequest(PoHttpContext context, PoHttpSession session, string pageKey)
        {
            if (!_sessionPages.TryGetValue(session.ID, out var pagesByUrl)) return;
            if (!pagesByUrl.TryGetValue(CreatePageKey(context.Request), out var page)) return;
            page.Index(context.Request);
            if (context.Request.QueryString.ContainsKey("clientaction"))
            {
                var json = page.GetModificationsAsJson(session.LastVisited);
                context.Response.WriteStringToOutput(json);
                context.Response.SendSuccess();
                return;
            }
            context.Response.WriteStringToOutput(page.ToHtml());
            context.Response.SendSuccess();
        }

        private bool CreatePageInSession_IfPageNotExists(PoHttpContext context, string sessionId, string pageKey)
        {
            if (!_sessionPages.TryGetValue(sessionId, out var pagesByUrl)) return false;
            if (pagesByUrl.TryGetValue(CreatePageKey(context.Request), out var page)) return false;
            page = CreateSessionPage(context, sessionId, pageKey);
            page.Index(context.Request);
            _sessionPages[sessionId].TryAdd(CreatePageKey(context.Request), page);
            context.Response.WriteStringToOutput(page.ToHtml());
            context.Response.SendSuccess();
            return true;
        }

        private bool CreateSession_IfNotExists(PoHttpContext context, string sessionId, string pageKey)
        {
            if (_sessionPages.TryGetValue(sessionId, out var pagesByUrl)) return false;
            var sessionPage = CreateSessionPage(context, sessionId, pageKey);
            sessionPage.Index(context.Request);
            pagesByUrl = new ConcurrentDictionary<string, PoUIComponent>();
            pagesByUrl.TryAdd(CreatePageKey(context.Request), sessionPage);
            _sessionPages.TryAdd(sessionId, pagesByUrl);
            context.Response.WriteStringToOutput(sessionPage.ToHtml());
            context.Response.SendSuccess();
            return true;
        }

        private bool RedirectToDesktop_IfInvalidPath(PoHttpContext context, string pageKey)
        {
            if (!string.IsNullOrEmpty(pageKey)) return false;
            context.Response.Redirect(RootUrlDesktop);
            context.Response.SendRedirect();
            return true;
        }

        private string CreatePageKey(PoHttpRequest request)
        {
            var abPath = request.Url.AbsolutePath;
            if (abPath.StartsWith("/Desktop", StringComparison.InvariantCultureIgnoreCase)) return RootUrlDesktop;
            if (!request.QueryString.TryGetValue("Name", out var name)) return string.Empty;
            if (!request.QueryString.TryGetValue("Page", out var page)) return string.Empty;
            return $"{RootUrlApp}_{name}_{page}";
        }
    }
}
