using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public abstract partial class PoUIComponent<T> : PoUIComponent where T : PoUIModel, new()
    {
        public T Model;

        public string Value
        {
            get { return Model.ValueBetweenTags; }
            set
            {
                IsDirty = true;
                Model.ValueBetweenTags = value;
            }
        }

        public PoUIComponent()
        {
            Model = new T();
        }

        public string ID
        {
            get
            {
                if (!string.IsNullOrEmpty(Model.ID)) return Model.ID;
                Model.ID = PoCommonStrings.GenerateRandomStr();
                return Model.ID;
            }
            set { Model.ID = value; }
        }

        public override string ToHtml()
        {
            var script = Scipt.CreateScript();
            var style = Style.CreateStyle();
            var html = Model.CreateModel(script, style);
            return html;
        }
    }

    public abstract class PoUIComponent
    {
        public PoUIEvents Scipt;
        public PoUIStyle Style;

        public PoUIComponent()
        {
            Scipt = new PoUIEvents();
            Style = new PoUIStyle();
        }

        public virtual List<PoUIHeadElement> HeadElements()
        {
            var headElements = new List<PoUIHeadElement>();
            return headElements;
        }

        protected bool IsDirty;
        protected void Refresh()
        {
            IsDirty = true;
        }

        public virtual string ToHtml()
        {
            return string.Empty;
        }
    }
}
