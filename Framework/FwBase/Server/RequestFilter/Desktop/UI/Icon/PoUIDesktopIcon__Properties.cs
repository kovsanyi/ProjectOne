using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIDesktopIcon
    {
        //PoUIImage _appIcon;
        //protected PoUIImage AppIcon
        //{
        //    get { return _appIcon; }
        //    set { _appIcon = value; SetValue(); }
        //}

        string _appIcon;
        public string AppIcon
        {
            get { return _appIcon; }
            set { _appIcon = value; SetValue(); }
        }


        string _appName;
        public string AppName
        {
            get { return _appName; }
            set { _appName = value; SetValue(); }
        }

        string _appPopup;
        public string AppPopup
        {
            get { return _appPopup; }
            set { _appPopup = value; SetValue(); }
        }

        string _appLink;
        public string AppLink
        {
            get { return _appLink; }
            set { _appLink = value; SetValue(); }
        }
    }
}
