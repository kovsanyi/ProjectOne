using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIModelTextArea : PoUIModel
    {
        public bool AutoFocus;
        public int? Cols;
        public string DirName;
        public bool Disabled;
        public string Form;
        public int? MaxLength;
        public string Name;
        public string Placeholder;
        public bool Readonly;
        public bool Required;
        public int? Rows;
        public string Wrap;

        public PoUIModelTextArea() : base("textarea") { }

        protected override string CreateAttributes()
        {
            var sb = new StringBuilder(base.CreateAttributes())
                .Append(CreateAttribute("autofocus", AutoFocus, false))
                .Append(CreateAttribute("cols", Cols?.ToString() ?? string.Empty))
                .Append(CreateAttribute("dirname", DirName))
                .Append(CreateAttribute("disabled", Disabled, false))
                .Append(CreateAttribute("form", Form))
                .Append(CreateAttribute("maxlength", MaxLength?.ToString() ?? string.Empty))
                .Append(CreateAttribute("name", Name))
                .Append(CreateAttribute("placeholder", Placeholder))
                .Append(CreateAttribute("readonly", Readonly, false))
                .Append(CreateAttribute("required", Required, false))
                .Append(CreateAttribute("rows", Rows?.ToString() ?? string.Empty))
                .Append(CreateAttribute("wrap", Wrap));
            var ret = sb.ToString().TrimStart();
            return ret;
        }
    }
}
