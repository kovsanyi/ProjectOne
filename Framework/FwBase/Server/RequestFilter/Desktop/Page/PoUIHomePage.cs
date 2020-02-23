//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ProjectOne
//{
//    public class PoUIHomePage : PoUIPage
//    {
//        protected override List<PoUIHeadElement> HeadElements()
//        {
//            var list = base.HeadElements();
//            //list.Add(new PoUIHeadElementCSS("/resource/Desktop.css"));
//            return list;
//        }
//        public PoUIHomePage()
//        {
//            var wrapper = new PoUILayout();
//            wrapper.Model.ID = "wrapper";

//            wrapper.Add(PoUIDesktop.Instance);
//            wrapper.Add(PoUITaskbar.Instance);

//            Title = "Home";
//            Body = wrapper;
//        }
//    }
//}
