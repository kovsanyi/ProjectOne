using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUILayout : IEnumerable<PoUIComponent>
    {
        public IEnumerator<PoUIComponent> GetEnumerator()
        {
            lock (_sync)
            {
                return _items.GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
