using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoAppChatServer
    {
        const string PAGE_HOME = "Home";
        const string PAGE_USER = "User";
        const string PAGE_EVENTS = "Events";
        const string PAGE_SETTINGS = "Settings";

        public void CreateMenu(PoUIMapMenu mapMenu)
        {
            //mapMenu.AddMenu("",)
        }

        public void CreateToolbar(PoUIMapToolbar mapToolbar)
        {
            mapToolbar.AddToolbarItem(PAGE_HOME, PAGE_HOME, PoIcon.App_Home, string.Empty);
            mapToolbar.AddToolbarItem(PAGE_USER, PAGE_USER, PoIcon.App_User, string.Empty);
            mapToolbar.AddSeparator();
            mapToolbar.AddToolbarItem(PAGE_EVENTS, PAGE_EVENTS, PoIcon.App_Events, "Events occured in the application");
            mapToolbar.AddToolbarItem(PAGE_SETTINGS, PAGE_SETTINGS, PoIcon.App_Settings, "Manage application settings");
            mapToolbar.AddSeparator();
            mapToolbar.AddExit();
        }

        public void CreatePages(PoUIMapPage mapPage)
        {
            mapPage.AddPage(PAGE_HOME, PAGE_HOME, typeof(PoUIChatServerPage_Home));
        }
    }
}
