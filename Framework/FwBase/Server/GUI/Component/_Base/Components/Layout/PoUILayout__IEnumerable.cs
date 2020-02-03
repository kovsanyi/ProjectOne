using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUILayout : IEnumerable<PoUIComponent>, IEnumerable
    {
        public IEnumerator<PoUIComponent> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
