using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoRequestFilterApp : IPoRequestFilter
    {
        public bool ProcessRequest(PoHttpContext context)
        {
            return false;
        }
    }
}
