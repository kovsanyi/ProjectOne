using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ProjectOne
{
    partial class PoItemManager<T>
    {
        bool _deserialized;

        protected void DeserializeItems()
        {
            if (string.IsNullOrEmpty(_persistenceDir)) return;
            if (_deserialized) return;
            var files = Directory.GetFiles(_persistenceDir);
            if (files.Length == 0)
            {
                _deserialized = true;
                OnCreated();
                OnLoaded();
                return;
            }
            foreach (var f in files)
            {
                var bf = new BinaryFormatter();
                try
                {
                    var stream = new FileStream(f, FileMode.Open, FileAccess.Read);
                    var item = bf.Deserialize(stream) as T;
                    stream.Close();
                    _items.Add(item);
                }
                catch (Exception e)
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                        $"Cannot deserialize item: {f}. Exception: {e.Message}");
                }
            }
            _deserialized = true;
            OnLoaded();
        }
    }
}
