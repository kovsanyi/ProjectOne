using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoSessionContainer
    {
        private bool RedirectToDesktop_IfCloseRequest_AndDoDispose(PoHttpContext context, PoHttpSession session)
        {
            if (!context.Request.RawUrl.StartsWith(RootUrlClose, StringComparison.InvariantCultureIgnoreCase)) return false;
            if (!context.Request.QueryString.TryGetValue("Name", out var appName)) return false;
            if (!PoAppManager.AppsMapped.TryGetValue(appName, out var app)) return false;
            if (!_sessionPages.TryGetValue(session.ID, out var pages)) return false;

            var pageKeyPrefix = $"{RootUrlApp}_{appName}_";
            var pagesToDispose = new List<PoUIPage>();
            foreach (var pageByKey in pages.ToArray())
            {
                if (!pageByKey.Key.StartsWith(pageKeyPrefix, StringComparison.InvariantCultureIgnoreCase)) continue;
                _sessionPages[session.ID].TryRemove(pageByKey.Key, out var tmp);
                pagesToDispose.Add(pageByKey.Value);
            }

            var taskbar = GetOrCreateTaskbar(session.ID);
            taskbar.CloseApp(app);
            context.Response.RedirectLocation = RootUrlDesktop;
            context.Response.SendRedirect();

            PoBackgroundJob.Enqueue(() => DisposeComponents(pagesToDispose),
                $"SessionContainer/DisposeComponents/{appName}");
            return true;
        }

        private void DisposeComponents(IEnumerable<PoUIPage> components)
        {
            foreach (var c in components)
            {
                try
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Disposing page {c.GetType().Name} {c.Title}...");
                    c.Dispose();
                }
                catch (Exception e)
                {
                    PoLogger.LogException(PoLogSource.Default, e, $"Error occured while disposing component: {c.GetType().Name}");
                }
            }
        }
    }
}
