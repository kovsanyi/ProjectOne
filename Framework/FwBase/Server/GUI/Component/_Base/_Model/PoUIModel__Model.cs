using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIModel
    {
        //public string CreateModel()
        //{
        //    var attributes = CreateAttributes();
        //    var eventAttributes = string.Empty;
        //    if (Scipt != null) eventAttributes = Scipt.CreateScript();
        //    var ret = $"<{Tag ?? ""}{attributes}{eventAttributes}>{ValueBetweenTags ?? ""}</{Tag ?? ""}>";
        //    return ret;
        //}

        public string CreateModel(string script, string style)
        {
            if (string.IsNullOrWhiteSpace(Tag)) return string.Empty;
            var attributes = CreateAttributes();
            script = string.IsNullOrWhiteSpace(script) ? string.Empty : script;
            style = string.IsNullOrWhiteSpace(style) ? string.Empty : CreateAttribute("style", style);
            var ret = $"<{Tag} {attributes} {style} {script}>{ValueBetweenTags ?? string.Empty}</{Tag}>";
            return ret;
        }
    }
}
