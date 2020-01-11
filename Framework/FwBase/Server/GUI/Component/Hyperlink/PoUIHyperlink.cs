using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIHyperlink : PoUIComponent
    {
        public PoUIHyperlink()
        {
            Model = new PoUIModelHyperlink();
            Model.Tag = "a";
        }
    }
}
