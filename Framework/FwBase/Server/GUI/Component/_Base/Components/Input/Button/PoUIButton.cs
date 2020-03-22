using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIButton : PoUIComponent<PoUIModelButton>
    {
        public PoButtonStyle Style
        {
            set
            {
                switch (value)
                {
                    case PoButtonStyle.Info:
                        AddClass("btn-info");
                        break;
                    default:
                        RemoveClass("btn-info");
                        break;
                }
                Refresh();
            }
        }

        public override List<PoUIHeadElement> HeadElements()
        {
            var he = base.HeadElements();
            he.Add(new PoUIHeadElementCSS("/resource/PoButton.css"));
            return he;
        }

        public PoUIButton() : base()
        {
            AddClass("btn");
        }
    }
}
