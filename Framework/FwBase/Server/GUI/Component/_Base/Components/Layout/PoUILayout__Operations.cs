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
            Refresh();
        }

        public void Clear()
        {
            _items.Clear();
            Value = string.Empty;
            Refresh();
        }

        public override string ToHtml()
        {
            var sb = new StringBuilder();
            foreach (var item in _items)
            {
                sb.Append(item.ToHtml());
            }

            Value = sb.ToString();
            return base.ToHtml();
        }
    }
}
