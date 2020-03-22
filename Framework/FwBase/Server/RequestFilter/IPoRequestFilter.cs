using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public interface IPoRequestFilter
    {
        string Name { get; }

        bool ProcessRequest(PoHttpContext context);
    }
}
