using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ProjectOne
{
    partial class PoItemManager<T>
    {
        protected void SerializeItems()
        {
            if (string.IsNullOrEmpty(_persistenceDir)) return;
            if (_items.Count == 0) return;
            PoFileManager.CreateDirIfNE(_persistenceDir);
            foreach (var item in _items)
            {
                var fullPath = Path.Combine(_persistenceDir, item.ID);
                var bf = new BinaryFormatter();
                try
                {
                    var stream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    bf.Serialize(stream, item);
                    stream.Close();
                }
                catch (Exception e)
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Cannot serialize item: {item.ToString()}. Exception: {e.Message}");
                }
            }
        }

        protected void SerializeItem(T item)
        {
            if (string.IsNullOrEmpty(_persistenceDir)) return;
            if (item == null) return;
            PoFileManager.CreateDirIfNE(_persistenceDir);
            var fullPath = Path.Combine(_persistenceDir, item.ID);
            var bf = new BinaryFormatter();
            try
            {
                var stream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                bf.Serialize(stream, item);
                stream.Close();
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Cannot serialize item: {item.ToString()}. Exception: {e.Message}");
            }
        }
    }
}
