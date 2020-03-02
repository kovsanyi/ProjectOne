using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUILayout : ICollection<PoUIComponent>
    {
        public void Add(PoUIComponent item)
        {
            if (item == null)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Null item cannot be added to {GetType().Name}");
                return;
            }
            _items.Add(item);
            Refresh();
        }

        public void Clear()
        {
            _items.Clear();
            Refresh();
        }

        public bool Contains(PoUIComponent item)
        {
            var ret = _items.Contains(item);
            return ret;
        }

        public void CopyTo(PoUIComponent[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(PoUIComponent item)
        {
            var ret = _items.Remove(item);
            return ret;
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
    }
}
