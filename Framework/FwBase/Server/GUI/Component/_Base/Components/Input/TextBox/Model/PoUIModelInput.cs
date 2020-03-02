using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public /*abstract*/ class PoUIModelInput : PoUIModel
    {
        public string Accept;
        public string Alt;
        public string AutoComplete;
        public string AutoFocus;
        public string Checked;
        public string DirName;
        public string Disabled;
        public string Form;
        public string FormAction;
        public string FormEncType;
        public string FormMethod;
        public string FormNoValidate;
        public string FormTarget;
        public string Height;
        public string List;
        public string Max;
        public string MaxLength;
        public string Min;
        public string Multiple;
        public string Name;
        public string Pattern;
        public string Placeholder;
        public string ReadOnly;
        public string Required;
        public string Size;
        public string Source;
        public string Step;
        public string Type;
        public string Value;
        public string Width;

        public PoUIModelInput() : base("input") { }

        protected override string CreateAttributes()
        {
            var sb = new StringBuilder(base.CreateAttributes())
                .Append(CreateAttribute("accept", Accept))
                .Append(CreateAttribute("alt", Alt))
                .Append(CreateAttribute("autocomplete", AutoComplete))
                .Append(CreateAttribute("autofocus", AutoFocus))
                .Append(CreateAttribute("checked", Checked))
                .Append(CreateAttribute("dirname", DirName))
                .Append(CreateAttribute("disabled", Disabled))
                .Append(CreateAttribute("form", Form))
                .Append(CreateAttribute("formaction", FormAction))
                .Append(CreateAttribute("formenctype", FormEncType))
                .Append(CreateAttribute("formmethod", FormMethod))
                .Append(CreateAttribute("formnovalidate", FormNoValidate))
                .Append(CreateAttribute("formtarget", FormTarget))
                .Append(CreateAttribute("height", Height))
                .Append(CreateAttribute("list", List))
                .Append(CreateAttribute("max", Max))
                .Append(CreateAttribute("maxlength", MaxLength))
                .Append(CreateAttribute("min", Min))
                .Append(CreateAttribute("multiple", Multiple))
                .Append(CreateAttribute("name", Name))
                .Append(CreateAttribute("pattern", Pattern))
                .Append(CreateAttribute("placeholder", Placeholder))
                .Append(CreateAttribute("readonly", ReadOnly))
                .Append(CreateAttribute("required", Required))
                .Append(CreateAttribute("size", Size))
                .Append(CreateAttribute("src", Source))
                .Append(CreateAttribute("step", Step))
                .Append(CreateAttribute("type", Type))
                .Append(CreateAttribute("value", Value))
                .Append(CreateAttribute("width", Width));
            var ret = sb.ToString().TrimStart();
            return ret;
        }
    }
}
