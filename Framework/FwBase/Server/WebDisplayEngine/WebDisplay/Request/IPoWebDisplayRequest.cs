using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public interface IPoWebDisplayRequest
    {
        void Process(PoHttpContext context, Dictionary<string, PoUIComponent> components);
    }
}
