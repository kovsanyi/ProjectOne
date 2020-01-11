using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIModelHyperlink : PoUIModel
    {
        public string Download;
        public string Href;
        public string HrefLang;
        public string Media;
        public string Ping;
        public string ReferrelPolicy;
        public string Rel;
        public string Target;
        public string Type;

        public override string CreateAttributes()
        {
            var ret = base.CreateAttributes() + "" +
                CreateAttribute("download", Download) +
                CreateAttribute("href", Href) +
                CreateAttribute("hreflang", HrefLang) +
                CreateAttribute("media", Media) +
                CreateAttribute("ping", Ping) +
                CreateAttribute("referrerpolicy", ReferrelPolicy) +
                CreateAttribute("rel", Rel) +
                CreateAttribute("target", Target) +
                CreateAttribute("type", Type);
            return ret;
        }
    }
}
