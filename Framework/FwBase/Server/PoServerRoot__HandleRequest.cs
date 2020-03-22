using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        void handleRequest(object state)
        {
            var context = (HttpListenerContext)state;
            processRequest(context);
        }
    }
}
