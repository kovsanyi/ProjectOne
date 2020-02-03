using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIModelImage : PoUIModel
    {
        public string AlternateText;
        public string CrossOrigin;
        public string Height;
        public string LongDescription;
        public string Source;
        public string UseMap;
        public string Width;

        public bool IsMap;

        public PoUIModelImage()
        {
            Tag = "img";
        }

        protected override string CreateAttributes()
        {
            var ret = base.CreateAttributes() +
                CreateAttribute("alt", AlternateText) +
                CreateAttribute("crossorigin", CrossOrigin) +
                CreateAttribute("height", Height) +
                CreateAttribute("longdesc", LongDescription) +
                CreateAttribute("src", Source) +
                CreateAttribute("usemap", UseMap) +
                CreateAttribute("width", Width) +
               (IsMap ? "ismap" : "");
            return ret;
        }
    }
}
