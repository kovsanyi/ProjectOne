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

        public void ProcessRequest(PoHttpContext context, string sessionId)
        {
            //nagyon TODO!
            var rootUrl = GetRootUrl(context, sessionId);
            // Invalid url, redirect to desktop
            if (string.IsNullOrEmpty(rootUrl))
            {
                context.Response.Redirect(RootUrlDesktop);
                context.Response.SendRedirect();
                return;
            }
            // If there is no active session, create one
            if (!_sessionPages.TryGetValue(sessionId, out var pagesByUrl))
            {
                var sessionPage = CreateSessionPage(context, sessionId, rootUrl);
                sessionPage.Index(context.Request);
                pagesByUrl = new ConcurrentDictionary<string, PoUIComponent>();
                //pagesByUrl.TryAdd(rootUrl, sessionPage);
                pagesByUrl.TryAdd(context.Request.Url.AbsoluteUri.ToLowerInvariant(), sessionPage);
                _sessionPages.TryAdd(sessionId, pagesByUrl);
                context.Response.WriteStringToOutput(sessionPage.ToHtml());
                context.Response.SendSuccess();
                return;
            }
            // If the page is not created, create one
            if (!pagesByUrl.TryGetValue(context.Request.Url.AbsoluteUri.ToLowerInvariant(), out var page))
            {
                page = CreateSessionPage(context, sessionId, rootUrl);
                page.Index(context.Request);
                //_sessionPages[sessionId].TryAdd(rootUrl, page);
                _sessionPages[sessionId].TryAdd(context.Request.Url.AbsoluteUri.ToLowerInvariant(), page);
                context.Response.WriteStringToOutput(page.ToHtml());
                context.Response.SendSuccess();
                return;
            }
            page.Index(context.Request);
            context.Response.WriteStringToOutput(page.ToHtml());
            context.Response.SendSuccess();
        }

        private string GetRootUrl(PoHttpContext context, string sessionId)
        {
            var absolutePathLower = context.Request.Url.AbsolutePath.ToLowerInvariant();
            if (absolutePathLower.StartsWith("/Desktop".ToLowerInvariant())) return "/desktop";
            if (absolutePathLower.StartsWith("/App".ToLowerInvariant())) return "/app";
            PoLogger.Log(PoLogSource.Default, PoLogType.Warn,
                "Cannot determine page url: " + absolutePathLower + ". Session Id: " + sessionId);
            return string.Empty;
        }
    }
}
