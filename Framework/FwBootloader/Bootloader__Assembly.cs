using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectOne
{
    partial class Bootloader
    {
        static string StarterPath;

        public static void LoadAssemblies()
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.TopDirectoryOnly);
            StarterPath = files.FirstOrDefault(x => x.EndsWith("Starter.dll"));
            if (string.IsNullOrEmpty(StarterPath)) return;
            var libraries = files.Where(x => x.EndsWith(".dll")).ToList();
            if (libraries.Count == 0) return;
            foreach (var dll in libraries)
            {
                Assembly.LoadFile(dll);
            }
        }

        public static void TakeOverAssemblyResolve()
        {
            return;
            var ad = AppDomain.CurrentDomain;
            //ad.AssemblyResolve += Ad_AssemblyResolve;
        }

        //private static Assembly Ad_AssemblyResolve(object sender, ResolveEventArgs args)
        //{

        //}
    }
}
