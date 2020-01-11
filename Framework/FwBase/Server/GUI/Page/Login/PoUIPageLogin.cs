using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIPageLogin : PoUIPage
    {
        public PoUIPageLogin() : base()
        {
            var heading = new PoUIHeading(PoUIHeadingType.H1);
            heading.ID = "ID_LOGINPAGE_HEADING";
            heading.Value = "Login";

            var btn = new PoUIButton();
            btn.ID = "ID_LOGINPAGE_BUTTON_LOGIN";
            btn.Value = "Login as admin";
            btn.Events.InitScript(PoUIEventType.OnClick);
            btn.Events.OnClick += Events_OnClick;

            var wrapper = new PoUILayout();
            wrapper.ID = "ID_LOGINPAGE_WRAPPER";
            wrapper.Add(heading);
            wrapper.Add(btn);

            Title = "Login";
            Body = wrapper;
        }

        private void Events_OnClick(object sender, EventArgs e)
        {
            ;
        }
    }
}
