using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    public partial class PoUILayout : PoUIComponent<PoUIModelConfigurable>
    {
        List<PoUIComponent> _items;

        public PoUILayout()
        {
            Model.Configure("div");
            _items = new List<PoUIComponent>();
        }

        public override List<PoUIHeadElement> HeadElements()
        {
            var headElements = base.HeadElements();
            foreach (var item in _items)
                headElements.AddRange(item.HeadElements());
            return headElements;
        }
    }
}
