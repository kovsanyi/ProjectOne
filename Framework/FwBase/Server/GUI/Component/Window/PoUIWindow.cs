using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIWindow : PoUILayout
    {
        private PoUIComponent _content;
        protected virtual PoUIComponent Content
        {
            get => _content;
            set
            {
                Remove(_content);
                _content = value;
                if (_content is PoUIComponent<PoUIModel> c)
                    c.AddClass("window-content");
                Add(_content);
                Refresh();
            }
        }

        public PoUIWindow(string title = null, string icon = null)
        {
            AddClass("window-form");
            CreateHeader(title, icon);
        }
    }
}
