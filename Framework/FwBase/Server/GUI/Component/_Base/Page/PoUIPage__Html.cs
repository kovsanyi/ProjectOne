using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIPage
    {
        public override string ToHtml()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<head>");
            sb.AppendLine(GetStandard());
            sb.AppendLine(GetMetaData());
            sb.AppendLine(GetHeadElementsBase());
            sb.AppendLine(GetHeadElements());
            sb.AppendLine("</head>");
            sb.AppendLine("</body>");
            sb.AppendLine(GetBody());
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
            var ret = sb.ToString();
            return ret;
        }

        private string GetStandard()
        {
            var title = $"<title>{Title}</title>";
            var charset = $"<meta charset=\"{Charset}\">";
            var sb = new StringBuilder();
            sb.AppendLine(title);
            sb.AppendLine(charset);
            var ret = sb.ToString();
            return ret;
        }

        private string GetMetaData()
        {
            if (_metaData == null || _metaData.Count == 0) return string.Empty;
            var sb = new StringBuilder();
            foreach (var meta in _metaData)
            {
                var attr = $"<meta name=\"{meta.Key}\" content=\"{meta.Value}\">";
                sb.AppendLine(attr);
            }
            var ret = sb.ToString();
            return ret;
        }

        private string GetHeadElements()
        {
            var headElements = HeadElements();
            if (headElements == null || headElements.Count == 0) return string.Empty;
            var sb = new StringBuilder();
            foreach (var he in headElements)
            {
                var attr = he.ToHTML();
                sb.AppendLine(attr);
            }
            var ret = sb.ToString();
            return ret;
        }

        private string GetHeadElementsBase()
        {
            PoUIHeadElement jQuery;
#if RELEASE
            jQuery = new PoUIHeadElementJS(GetResourceStr("jquery-3.4.1.min.js"));
#else
            jQuery = new PoUIHeadElementJS(GetResourceStr("jquery-3.4.1.js"));
#endif
            var mainJs = new PoUIHeadElementJS(GetResourceStr("Main.js"));
            var sb = new StringBuilder();
            sb.AppendLine(jQuery.ToHTML());
            sb.AppendLine(mainJs.ToHTML());
            var ret = sb.ToString();
            return ret;
        }

        private string GetResourceStr(string resource)
        {
            var ret = "/resource/" + resource;
            return ret;
        }

        private string GetBody()
        {
            var ret = Body?.ToHtml() ?? string.Empty;
            return ret;
        }
    }
}
