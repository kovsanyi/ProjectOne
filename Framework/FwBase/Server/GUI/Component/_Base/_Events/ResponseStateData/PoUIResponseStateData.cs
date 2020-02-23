using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIResponseData
    {
        public bool Modified;
        public string SenderId;
        public List<PoUIResponseDataElement> Elements;
    }

    public class PoUIResponseDataElement
    {
        public string ComponentId;
        public string HtmlContent;
    }
}