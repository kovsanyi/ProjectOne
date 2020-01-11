using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIComponent
    {
        public PoUIModel Model;
        public PoUIEvents Events
        {
            get { return Model?.Events; }
        }

        protected bool IsDirty;
        public string Value
        {
            get { return Model.ValueBetweenTags; }
            set
            {
                IsDirty = true;
                Model.ValueBetweenTags = value;
            }
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

        protected virtual List<PoUIHeadElement> HeadElements()
        {
            var headElements = new List<PoUIHeadElement>();
            return headElements;
        }

        public PoUIComponent()
        {
            //ID = PoCommonStrings.GenerateRandomStr();
        }

        protected void Refresh()
        {
            IsDirty = true;
        }

        public virtual string ToHTML()
        {
            var ret = Model.Model;
            return ret;
        }
    }
}
