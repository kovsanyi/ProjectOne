using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectOne
{
    partial class PoServerRoot
    {
        public bool IdentifyUser(HttpListenerContext context)
        {
            var identify = context.User.Identity as HttpListenerBasicIdentity;
            var name = identify.Name;
            var password = identify.Password;

            return false;
        }
    }
}
