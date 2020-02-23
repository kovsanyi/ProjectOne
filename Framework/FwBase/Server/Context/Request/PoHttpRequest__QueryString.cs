using System.Collections.Generic;
using System.Collections.Immutable;
using System.Web;

namespace ProjectOne
{
    partial class PoHttpRequest
    {
        public readonly ImmutableDictionary<string, string> QueryString;
        private Dictionary<string, string> ParseQueryString()
        {
            if (_request == null) return new Dictionary<string, string>();
            var qmPos = _request.RawUrl.IndexOf('?');
            if (qmPos == -1) return new Dictionary<string, string>();
            var queryString = _request.RawUrl.Substring(qmPos);
            var nvc = HttpUtility.ParseQueryString(queryString);
            var dict = new Dictionary<string, string>(nvc.Count);
            foreach (var key in nvc.AllKeys)
            {
                if (dict.TryAdd(key, nvc[key]) && dict.TryAdd(key.ToLowerInvariant(), nvc[key])) continue;
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn,
                    $"Cannot process query string. It already contains an item with key '{key}'. It will be ignored.");
            }
            return dict;
        }
    }
}
