using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIScript
    {
        protected readonly Dictionary<PoUIEventType, string> Scripts;

        public PoUIScript()
        {
            Scripts = new Dictionary<PoUIEventType, string>();
        }

        public virtual string CreateScript()
        {
            if (Scripts == null || Scripts.Count == 0) return string.Empty;
            var sb = new StringBuilder();
            foreach (var script in Scripts)
            {
                var s = CreateScript(script.Key, script.Value);
                sb.Append(s);
            }
            var ret = sb.ToString();
            return ret;
        }

        protected string CreateScript(PoUIEventType scriptType, string content)
        {
            if (string.IsNullOrEmpty(content)) return string.Empty;
            var ret = " " + scriptType.ToString().ToLowerInvariant() + "=\"" + content + "\"";
            return ret;
        }

        public void SetCustom(PoUIEventType scriptType, string content)
        {
            if (string.IsNullOrEmpty(content)) return;
            if (Scripts.ContainsKey(scriptType))
            {
                Scripts.Remove(scriptType);
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn,
                    "Script replaced with SetCustom(PoUIScriptType, string) method: " + scriptType.ToString());
            }
            Scripts.Add(scriptType, content);
        }

        public void InitScript(PoUIEventType scriptType)
        {
            if (Scripts.ContainsKey(scriptType))
            {
                Scripts.Remove(scriptType);
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn,
                    "Script replaced with InitScript(PoUIScriptType) method: " + scriptType.ToString());
            }
            Scripts.Add(scriptType, $"{scriptType.ToString()}(this)");
        }
    }
}
