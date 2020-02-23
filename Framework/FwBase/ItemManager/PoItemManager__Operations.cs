using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    partial class PoItemManager<T>
    {
        public void Add(IEnumerable<T> items)
        {
            if (items == null) return;
            foreach (var item in items)
                Add(item);
        }

        public void Add(T item)
        {
            if (item == null) return;
            var itemExists = GetItems().FirstOrDefault(x => x.ID == item.ID);
            if (itemExists != null)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn, $"Item cannot be added to manager because it is already exists: {item.ToString()}");
                return;
            }
            _items.Add(item);
            SerializeItem(item);
        }

        public void Update(T item)
        {
            if (item == null) return;
            var itemExists = GetItems().FirstOrDefault(x => x.ID == item.ID);
            if (itemExists == null)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn, $"Item cannot be updated in manager because it is not exists: {item.ToString()}");
                return;
            }
            SerializeItem(item);
        }

        public void Remove(T item)
        {
            if (item == null) return;
            var itemExists = GetItems().FirstOrDefault(x => x.ID == item.ID);
            if (itemExists == null) return;
            _items.Remove(item);
            RemoveItemFromPersistence(item);
        }

        public List<T> GetItems()
        {
            if (string.IsNullOrEmpty(_persistenceDir)) return _items;
            if (_deserialized) return _items;
            DeserializeItems();
            return _items;
        }

        private void RemoveItemFromPersistence(T item)
        {
            if (string.IsNullOrEmpty(_persistenceDir)) return;
            if (item == null) return;
            var fullPath = Path.Combine(_persistenceDir, item.ID);
            if (!File.Exists(fullPath)) return;
            try
            {
                File.Delete(fullPath);
            }
            catch (Exception e)
            {
                PoLogger.LogException(PoLogSource.Default, e, $"Cannot delete item {nameof(T)} from persistence store.");
            }
        }
    }
}
