using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class PoUIPage : PoUIComponent
    {
        private readonly Dictionary<string, string> _metaData;
        private PoUIComponent _body;

        public string Title;
        public string Charset;

        public PoUIComponent Body
        {
            get => _body;
            set { _body = value; Refresh(); }
        }

        public PoUIPage(string title = "")
        {
            _metaData = new Dictionary<string, string>();
            Title = title;
            Charset = "UTF-8";
        }

        public override List<PoUIHeadElement> HeadElements()
        {
            var headElements = new List<PoUIHeadElement>();
            headElements.AddRange(_body?.HeadElements());
            headElements.Add(new PoUIHeadElementCSS("/resource/PoMaster.css"));
            headElements.Add(new PoUIHeadElementCSS("https://www.w3schools.com/w3css/4/w3.css"));
            return headElements;
        }

        public override void IndexChildren(ref Dictionary<string, PoUIComponent> children)
        {
            Body?.IndexChildren(ref children);
        }

        public void AddMeta(string name, string content)
        {
            if (_metaData == null) return;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(content)) return;
            var nameLower = name.ToLowerInvariant();
            if (_metaData.ContainsKey(nameLower)) return;
            _metaData.Add(name, content);
        }
    }
}
