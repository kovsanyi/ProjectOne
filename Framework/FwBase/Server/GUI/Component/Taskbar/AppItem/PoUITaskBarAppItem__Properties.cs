using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUITaskBarAppEntry
    {
        string _appName;
        public string AppName
        {
            get { return _appName; }
            set
            {
                _appName = value;
                SetValue();
            }
        }

        string _appTitle;
        public string AppTitle
        {
            get { return _appTitle; }
            set
            {
                _appTitle = value;
                SetValue();
            }
        }

        string _appIcon;
        public string AppIcon
        {
            get { return _appIcon; }
            set
            {
                _appIcon = value;
                SetValue();
            }
        }
    }
}
