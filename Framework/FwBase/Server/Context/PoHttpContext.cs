using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Net;
using System.Text;
using System.Web;

namespace ProjectOne
{
    public partial class PoHttpContext
    {
        private readonly HttpListenerContext _context;
        public readonly PoHttpRequest Request;
        public readonly PoHttpResponse Response;
        public readonly PoUser User;

        public PoHttpContext(HttpListenerContext context)
        {
            _context = context;
            User = DetermineUser();
            Request = new PoHttpRequest(context.Request, User);
            Response = new PoHttpResponse(context.Response);
        }

        private PoUser DetermineUser()
        {
            var basicIdentity = _context.User.Identity as HttpListenerBasicIdentity;
            if (basicIdentity == null) return new PoUser();
            var usernameWithDomain = basicIdentity.Name;
            var user = new PoUser();
            user.Username = GetUsername(usernameWithDomain);
            user.Domain = GetDomain(usernameWithDomain);
            return user;
        }

        private string GetUsername(string usernameWithDomain)
        {
            var atPos = usernameWithDomain.IndexOf('@');
            if (atPos == -1) return usernameWithDomain;
            var ret = usernameWithDomain.Substring(0, atPos);
            return ret;
        }

        private string GetDomain(string usernameWithDomain)
        {
            var atPos = usernameWithDomain.IndexOf('@');
            if (atPos == -1) return "localhost";
            var ret = usernameWithDomain.Substring(atPos + 1);
            return ret;
        }
    }
}
