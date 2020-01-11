using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectOne
{
    public partial class PoAppManager
    {
        public static readonly Dictionary<string, IPoApp> AppsMapped;
        static PoAppManager()
        {
            PoBootloader.Instance.LoadAssemblies();
            var appType = typeof(IPoApp);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.Select(x => x.GetTypes()).SelectMany(x => x).Where(t => t.IsClass && appType.IsAssignableFrom(t));
            //var types = Assembly.GetAssembly(appType).GetTypes().Where(t => t.IsClass && t.IsSubclassOf(appType));
            AppsMapped = new Dictionary<string, IPoApp>(types.Count());
            foreach (var t in types)
            {
                try
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Loading app: {t.Name}");
                    var obj = (IPoApp)Activator.CreateInstance(t);
                    var prefix = obj.AppPrefix;
                    AppsMapped.Add(prefix, obj);
                }
                catch (Exception e)
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Error while loading app: {t.Name}. {e.Message}");
                }
            }
        }

        public static void StartApps()
        {
            foreach (var app in AppsMapped.Values)
            {
                try
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Starting app: {app.Name}");
                    app.CallOnStarted();
                }
                catch (Exception e)
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Error while starting app: {app.Name}. {e.Message}");
                }
            }
        }

        public static void StopApps()
        {
            foreach (var app in AppsMapped.Values)
            {
                try
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Stopping app: {app.Name}");
                    app.CallOnStopped();
                }
                catch (Exception e)
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Error while stopping app: {app.Name}. {e.Message}");
                }
            }
        }
    }
}
