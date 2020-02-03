using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public partial class Bootloader
    {
        public static void Start()
        {
            LoadAssemblies();
            TakeOverAssemblyResolve();
            Boot();
        }
    }
}
