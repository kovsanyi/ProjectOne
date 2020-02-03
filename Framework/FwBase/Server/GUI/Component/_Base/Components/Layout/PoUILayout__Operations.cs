using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    partial class PoUILayout
    {
        public void Add(PoUIComponent item)
        {
            if (item == null) return;
            _items.Add(item);
            var htmlList = _items.Select(x => x.ToHtml());
            Value = htmlList.Aggregate((x, y) => x + y);
            //IsDirty = true;
        }

        public void Clear()
        {
            _items.Clear();
            Value = string.Empty;
            //IsDirty = true;
        }
    }
}
