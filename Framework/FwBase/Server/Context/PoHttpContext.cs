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

        public PoHttpContext(HttpListenerContext context)
        {
            _context = context;
            Request = new PoHttpRequest(context.Request);
            Response = new PoHttpResponse(context.Response);
        }
    }
}
