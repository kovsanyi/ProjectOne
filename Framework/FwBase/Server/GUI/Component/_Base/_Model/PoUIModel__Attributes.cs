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
        public string Style;
        public string Title;
        public int TabIndex;
        public bool ContentEditable;
        public bool Dragable;
        public bool Hidden;
        public bool SpellCheck;
        public bool Translate;

        public virtual string CreateAttributes()
        {
            var ret = "" +
                CreateAttribute("accesskey", AccessKey) +
                CreateAttribute("class", Class) +
                CreateAttribute("dir", Direction) +
                CreateAttribute("dropzone", DropZone) +
                CreateAttribute("id", ID) +
                CreateAttribute("lang", Lang) +
                CreateAttribute("style", Style) +
                CreateAttribute("title", Title) +
                (TabIndex > -1 ? CreateAttribute("tabindex", TabIndex.ToString()) : "") +
                (ContentEditable ? CreateAttribute("contenteditable", "true") : "") +
                (Dragable ? CreateAttribute("draggable", "true") : "") +
                (Hidden ? "hidden" : "") +
                (SpellCheck ? CreateAttribute("spellcheck", "true") : "") +
                (Translate ? "" : CreateAttribute("translate", "no"));
            return ret;
        }

        protected string CreateAttribute(string attribute, string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value)) return "";
            var ret = " " + attribute + "=\"" + value + "\"";
            return ret;
        }
    }
}
