using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUILayout : ICollection<PoUIComponent>
    {
        public void AddRange(IEnumerable<PoUIComponent> items)
        {
            if (items == null) return;
            lock (_items)
            {
                foreach (var item in items)
                    AddItem(item);
            }
            Refresh();
        }

        public void Add(PoUIComponent item)
        {
            lock (_items)
            {
                AddItem(item);
            }
            Refresh();
        }

        private void AddItem(PoUIComponent item)
        {
            if (item == null)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Null item cannot be added to {GetType().Name}");
                return;
            }
            _items.Add(item);
        }

        public void Clear()
        {
            lock (_sync)
            {
                _items.Clear();
            }
            Refresh();
        }

        public bool Contains(PoUIComponent item)
        {
            lock (_sync)
            {
                var ret = _items.Contains(item);
                return ret;
            }
        }

        public void CopyTo(PoUIComponent[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(PoUIComponent item)
        {
            lock (_sync)
            {
                var ret = _items.Remove(item);
                return ret;
            }
        }

        public int Count
        {
            get
            {
                lock (_sync)
                {
                    return _items.Count;
                }
            }
        }
        public bool IsReadOnly => false;
    }
}
