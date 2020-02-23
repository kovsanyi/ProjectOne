using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public abstract partial class PoUIComponent<T> : PoUIComponent where T : PoUIModel, new()
    {
        public T Model;

        public override string ID => Model?.ID;

        public string Value
        {
            get => Model.ValueBetweenTags;
            set
            {
                Model.ValueBetweenTags = value;
                IsDirty = true;
            }
        }

        protected PoUIComponent()
        {
            Model = new T();
            Model.ID = PoCommonStrings.GenerateRandomId();
        }

        public override string ToHtml()
        {
            var script = Script.CreateScript();
            var style = Style.CreateStyle();
            var html = Model.CreateModel(script, style);
            return html;
        }
    }
}
