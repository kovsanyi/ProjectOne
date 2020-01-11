using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ProjectOne
{
    partial class PoItemManager<T>
    {
        string _persistenceDir;

        protected void MakePersistence(params string[] paths)
        {
            var prefix = PoFileManager.ProjectOneDir;
            var path = Path.Combine(paths);
            var fullPath = Path.Combine(prefix, path);
            _persistenceDir = fullPath;
        }
    }
}
