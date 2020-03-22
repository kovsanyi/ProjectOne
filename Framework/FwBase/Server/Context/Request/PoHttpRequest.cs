using System.Collections.Immutable;
using System.Net;

namespace ProjectOne
{
    public partial class PoHttpRequest
    {
        public readonly PoUser User;
        private readonly HttpListenerRequest _request;

        public PoHttpRequest(HttpListenerRequest request, PoUser user)
        {
            _request = request;
            User = user;
            QueryString = ParseQueryString().ToImmutableDictionary();
        }
    }
}
