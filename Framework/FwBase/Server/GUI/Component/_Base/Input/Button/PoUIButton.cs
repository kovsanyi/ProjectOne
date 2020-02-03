using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIButton : PoUIComponent
    {
        public PoUIButton()
        {
            Model = new PoUIModel();
            Model.Tag = "button";
        }

        public virtual void CallOnClick() { }
    }
}
