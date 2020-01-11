using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public interface IPoRequestFilter
    {
        bool ProcessRequest(PoHttpContext context);
    }
}
