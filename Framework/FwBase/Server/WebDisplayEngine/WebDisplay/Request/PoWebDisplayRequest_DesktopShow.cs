//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ProjectOne
//{
//    public class PoWebDisplayRequest_DesktopShow : IPoWebDisplayRequest
//    {
//        public PoWebDisplayRequest_DesktopShow()
//        {

//        }

//        public void Process(PoHttpContext context, Dictionary<string, PoUIComponent> components)
//        {
//            var apps = PoAppManager.AppsMapped.Values.ToList();
//            //PoUIDesktop.Instance.LoadIcons(apps);
//            var html = new PoUIHomePage().ToHTML();
//        }
//    }
//}
