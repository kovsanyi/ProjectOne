using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIWindow : PoUILayout
    {
        public string Icon;

        private PoUIComponent _content;
        protected virtual PoUIComponent Content
        {
            get => _content;
            set
            {
                Remove(_content);
                _content = value;
                Add(_content);
                Refresh();
            }
        }

        public PoUIWindow(string title = null, string icon = null)
        {
            Icon = icon;
            AddClass("window");
            var header = createHeader(title);
            Add(header);
        }

        public override string ToHtml()
        {

            return base.ToHtml();
        }
    }
}
