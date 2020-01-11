using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ProjectOne
{
    partial class PoBootloader
    {
        public void LoadAssemblies()
        {
            var currDir = Directory.GetCurrentDirectory();
            PoLogger.Log(PoLogSource.Default, PoLogType.Info, "Loading assemblies located in: " + currDir);
            var files = Directory.GetFiles(currDir, "*.dll");
            foreach (var f in files)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(f);
                    PoLogger.Log(PoLogSource.Default, PoLogType.Info, "Assembly loaded: " + assembly.FullName);
                }
                catch (Exception)
                {
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error, "Falied to load assembly from file: " + f);
                }
            }
        }
    }
}
