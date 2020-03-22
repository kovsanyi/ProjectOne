using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoSessionContainer
    {
        public PoUIPage CreateSessionPage(PoHttpContext context, string sessionId, string pageKey)
        {
            if (pageKey.StartsWith(RootUrlDesktop, StringComparison.InvariantCultureIgnoreCase))
                return CreateSessionPageDesktop(context, sessionId);
            if (pageKey.StartsWith(RootUrlApp, StringComparison.InvariantCultureIgnoreCase))
                return CreateSessionPageApp(context, sessionId);
            return null;
        }

        private PoUIPage CreateSessionPageDesktop(PoHttpContext context, string sessionId)
        {
            var taskbar = GetOrCreateTaskbar(sessionId);
            var ret = new PoUIDesktopPage(taskbar);
            return ret;
        }

        private PoUIPage CreateSessionPageApp(PoHttpContext context, string sessionId)
        {
            if (!context.Request.QueryString.TryGetValue("Name".ToLowerInvariant(), out var appName)) return null;
            if (!context.Request.QueryString.TryGetValue("Page".ToLowerInvariant(), out var pageName)) return null;
            if (!CreatePage(appName, pageName, out var appContent, out var appOpened)) return null;
            var taskbar = GetOrCreateTaskbar(sessionId, appOpened);
            var page = CreatePage(appContent, taskbar, appName);
            return page;
        }

        private PoUIPage CreatePage(PoUIComponent appContent, PoUIComponent taskbar, string title)
        {
            //Wrapper
            var wrapper = new PoUILayout();
            wrapper.AddClass("wrapper");
            wrapper.Model.ID = "PoWrapper";
            wrapper.Add(appContent);
            wrapper.Add(taskbar);

            //Page
            var page = new PoUIPage(title);
            page.Body = wrapper;
            return page;
        }

        private PoUITaskbar GetOrCreateTaskbar(string sessionId, IPoApp app = null)
        {
            if (!_sessionTaskbar.TryGetValue(sessionId, out var taskbar))
                taskbar = new PoUITaskbar();
            _sessionTaskbar.TryAdd(sessionId, taskbar);
            if (app == null) return taskbar;
            taskbar.OpenApp(app);
            return taskbar;
        }
    }
}
