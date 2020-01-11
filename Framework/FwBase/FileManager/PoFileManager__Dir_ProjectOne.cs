using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectOne
{
    partial class PoFileManager
    {
        static string _projectOneDir;
        public static string ProjectOneDir
        {
            get { return _projectOneDir ?? evaluateDir_ProjectOne(); }
        }

        static string evaluateDir_ProjectOne()
        {
            var ad = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var ret = Path.Combine(ad, "ProjectOne");
            _projectOneDir = ret;
            return ret;
        }
    }
}
