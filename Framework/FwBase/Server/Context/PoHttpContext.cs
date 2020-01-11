using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    public partial class PoHttpContext
    {
        HttpListenerContext _context;

        public PoHttpContext(HttpListenerContext context)
        {
            _context = context;
        }
    }
}
