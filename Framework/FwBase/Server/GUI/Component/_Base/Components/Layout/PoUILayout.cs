using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    public partial class PoUILayout : PoUIComponent<PoUIModelConfigurable>
    {
        private readonly object _sync = new object();
        private readonly List<PoUIComponent> _items;

        public PoUILayout() : this(PoOrientationType.Vertical) { }

        public PoUILayout(PoOrientationType orientation)
        {
            Model.Configure("div");
            Orientation = orientation;
            _items = new List<PoUIComponent>();
        }

        public override List<PoUIHeadElement> HeadElements()
        {
            var headElements = base.HeadElements();
            lock (_sync)
            {
                foreach (var item in _items)
                    headElements.AddRange(item.HeadElements());
            }
            return headElements;
        }

        public override string ToHtml()
        {
            var sb = new StringBuilder();
            lock (_items)
            {
                foreach (var item in _items)
                {
                    var html = item.ToHtml();
                    sb.Append(html);
                }
            }
            Value = sb.ToString();
            return base.ToHtml();
        }
    }
}
