using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace ProjectOne
{
    partial class Bootloader
    {
        static void Boot()
        {
            if (string.IsNullOrEmpty(StarterPath)) return;
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(StarterPath);
            var main = assembly.GetType("ProjectOne.Program", true, false);
            var entryPoint = main.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).FirstOrDefault();
            if (entryPoint == null) return;
            entryPoint.Invoke(null, new object[] { new string[0] { } });
        }
    }
}
