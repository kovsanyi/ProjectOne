using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectOne
{
    public abstract partial class PoItemManager<T> where T : PoManagedItem
    {
        List<T> _items;

        public PoItemManager()
        {
            _items = new List<T>();
        }
    }
}
