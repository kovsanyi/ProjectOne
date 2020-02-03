using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIButton : PoUIComponent<PoUIModelConfigurable>
    {
        public PoUIButton()
        {
            Model.Configure("button");
        }

        public virtual void CallOnClick() { }
    }
}
