using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectOne
{
    public abstract partial class PoItemManager<T> where T : PoManagedItem
    {
        private readonly List<T> _items;

        protected PoItemManager()
        {
            _items = new List<T>();
        }
    }
}
