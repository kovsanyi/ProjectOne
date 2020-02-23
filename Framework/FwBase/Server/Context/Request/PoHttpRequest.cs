using System.Collections.Immutable;
using System.Net;

namespace ProjectOne
{
    public partial class PoHttpRequest
    {
        private readonly HttpListenerRequest _request;

        public PoHttpRequest(HttpListenerRequest request)
        {
            _request = request;
            QueryString = ParseQueryString().ToImmutableDictionary();
        }
    }
}
