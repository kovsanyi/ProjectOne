using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectOne
{
    public partial class PoResourceManager
    {
        public Dictionary<string, Assembly> ResourcesMapped;

        public void LoadResources()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var resources = assembly.GetManifestResourceNames();
                foreach (var res in resources)
                {
                    if (ResourcesMapped.TryAdd(res, assembly)) continue;
                    PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Could not load resource due to it is already exists: " + res);
                }
            }
            //ResourcesMapped = GetType().Assembly.GetManifestResourceNames();
            PoLogger.Log(PoLogSource.Default, PoLogType.Info, "Resources loaded.");
        }

        public bool TryGetResource(string resName, out byte[] resBytes)
        {
            resBytes = null;
            //var resNameLower = resName.ToLowerInvariant();
            var res = ResourcesMapped
                //.Select(x => x.ToLowerInvariant())
                .Where(x => x.Key.EndsWith(resName))
                .FirstOrDefault();
            if (res.Key == null || res.Value == null) return false;
            //if (res == default(KeyValuePair<string, Assembly>)) return false;
            using (var stream = res.Value.GetManifestResourceStream(res.Key))
            {
                resBytes = new byte[stream.Length];
                stream.Read(resBytes, 0, resBytes.Length);
            }
            return true;
        }
    }
}
