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
                _content.AddClass("window-content");
                Add(_content);
                Refresh();
            }
        }

        public PoUIWindow(string title = null, string iconSrcName = null)
        {
            AddClass("window-form");
            CreateHeader(title, iconSrcName);
        }
    }
}
