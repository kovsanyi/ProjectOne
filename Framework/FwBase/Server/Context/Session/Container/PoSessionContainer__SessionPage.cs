using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoSessionContainer
    {
        public PoUIComponent CreateSessionPage(PoHttpContext context, string sessionId, string rootUrl)
        {
            if (rootUrl.StartsWith(RootUrlDesktop, StringComparison.InvariantCultureIgnoreCase))
                return CreateSessionPageDesktop(context, sessionId);
            if (rootUrl.StartsWith(RootUrlApp, StringComparison.InvariantCultureIgnoreCase))
                return CreateSessionPageApp(context, sessionId);
            return null;
        }

        private PoUIComponent CreateSessionPageDesktop(PoHttpContext context, string sessionId)
        {
            var taskbar = GetOrCreateTaskbar(sessionId);
            var ret = new PoUIDesktopPage(taskbar);
            return ret;
        }

        private PoUIComponent CreateSessionPageApp(PoHttpContext context, string sessionId)
        {
            if (!context.Request.QueryString.TryGetValue("Name".ToLowerInvariant(), out var appName)) return null;
            if (!context.Request.QueryString.TryGetValue("Page".ToLowerInvariant(), out var pageName)) return null;
            if (!OpenAppPage(appName, pageName, out var appContent, out var appOpened)) return null;
            var taskbar = GetOrCreateTaskbar(sessionId, appOpened);

            //Create page
            var wrapper = new PoUILayout();
            wrapper.Add(appContent);
            wrapper.Add(taskbar);
            var page = new PoUIPage(appName);
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
