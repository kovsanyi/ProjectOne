using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    partial class PoHttpContext
    {
        public HttpListenerRequest Request
        {
            get { return _context?.Request; }
        }

        public HttpListenerResponse Response
        {
            get { return _context?.Response; }
        }
    }
}
