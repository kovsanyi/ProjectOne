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
        public string FormEnctype;
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

        public PoUIModelInput() : base()
        {

        }

        protected override string CreateAttributes()
        {
            var ret = base.CreateAttributes() + "" +
                CreateAttribute("accept", Accept) +
                CreateAttribute("alt", Alt) +
                CreateAttribute("autocomplete", AutoComplete) +
                CreateAttribute("autofocus", AutoFocus) +
                CreateAttribute("checked", Checked) +
                CreateAttribute("dirname", DirName) +
                CreateAttribute("disabled", Disabled) +
                CreateAttribute("form", Form) +
                CreateAttribute("formaction", FormAction) +
                CreateAttribute("formenctype", FormEnctype) +
                CreateAttribute("formmethod", FormMethod) +
                CreateAttribute("formnovalidate", FormNoValidate) +
                CreateAttribute("formtarget", FormTarget) +
                CreateAttribute("height", Height) +
                CreateAttribute("list", List) +
                CreateAttribute("max", Max) +
                CreateAttribute("maxlength", MaxLength) +
                CreateAttribute("min", Min) +
                CreateAttribute("multiple", Multiple) +
                CreateAttribute("name", Name) +
                CreateAttribute("pattern", Pattern) +
                CreateAttribute("placeholder", Placeholder) +
                CreateAttribute("readonly", ReadOnly) +
                CreateAttribute("required", Required) +
                CreateAttribute("size", Size) +
                CreateAttribute("src", Source) +
                CreateAttribute("step", Step) +
                CreateAttribute("type", Type) +
                CreateAttribute("value", Value) +
                CreateAttribute("width", Width);
            return ret;
        }
    }
}
