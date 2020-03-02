using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIModel
    {
        public string AccessKey;
        public string Class;
        public string Direction;
        public string DropZone;
        public string ID;
        public string Lang;
        //public string Style;
        public string Title;
        public int TabIndex;
        public bool ContentEditable;
        public bool Draggable;
        public bool Hidden;
        public bool SpellCheck;
        public bool Translate;

        protected virtual string CreateAttributes()
        {
            var sb = new StringBuilder()
                .Append(CreateAttribute("accesskey", AccessKey))
                .Append(CreateAttribute("class", Class))
                .Append(CreateAttribute("dir", Direction))
                .Append(CreateAttribute("dropzone", DropZone))
                .Append(CreateAttribute("id", ID))
                .Append(CreateAttribute("lang", Lang))
                //.Append(CreateAttribute("style", Style))
                .Append(CreateAttribute("title", Title))
                .Append(TabIndex > -1 ? CreateAttribute("tabindex", TabIndex.ToString()) : "")
                .Append(ContentEditable ? CreateAttribute("contenteditable", "true") : "")
                .Append(Draggable ? CreateAttribute("draggable", "true") : "")
                .Append(CreateAttribute("hidden", Hidden, false))
                .Append(SpellCheck ? CreateAttribute("spellcheck", "true") : "")
                .Append(Translate ? string.Empty : CreateAttribute("translate", "no"));
            var ret = sb.ToString().TrimStart();
            return ret;
        }

        protected string CreateAttribute(string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute) || string.IsNullOrEmpty(value)) return string.Empty;
            var ret = $" {attribute.ToLowerInvariant()}=\"{value}\"";
            return ret;
        }

        protected string CreateAttribute(string attribute, bool value, bool defaultValue)
        {
            var ret = value == defaultValue ? string.Empty : attribute.ToLowerInvariant();
            return ret;
        }
    }
}
