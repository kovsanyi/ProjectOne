using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIModelButton : PoUIModel
    {
        public bool AutoFocus;
        public bool Disabled;
        public string Form;
        public string FormAction;
        public string FormEncType;
        public PoUicFormMethod FormMethod;
        public bool FormNoValidate;
        public string FormTarget;
        public string Name;
        public PoUicButtonType Type;
        public string Value;

        public PoUIModelButton() : base("button") { }

        protected override string CreateAttributes()
        {
            var sb = new StringBuilder(base.CreateAttributes())
                .Append(CreateAttribute("autofocus", AutoFocus, false))
                .Append(CreateAttribute("disabled", Disabled, false))
                .Append(CreateAttribute("form", Form))
                .Append(CreateAttribute("formaction", FormAction))
                .Append(CreateAttribute("formenctype", FormEncType))
                .Append(CreateAttribute("formmethod", FormMethod.ToString().ToLowerInvariant()))
                .Append(CreateAttribute("formnovalidate", FormNoValidate, false))
                .Append(CreateAttribute("formtarget", FormTarget))
                .Append(CreateAttribute("name", Name))
                .Append(CreateAttribute("type", Type.ToString().ToLowerInvariant()))
                .Append(CreateAttribute("value", Value));
            var ret = sb.ToString().TrimStart();
            return ret;
        }
    }
}
