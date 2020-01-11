using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectOne
{
    public static partial class PoFileManager
    {
        public static void CreateDirIfNE(string path)
        {
            if (Directory.Exists(path)) return;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Cannot create directory: {path}. Exception: {e.Message}");
            }
        }
    }
}
