using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIScript
    {
        public void HandleRequest(PoHttpRequest request)
        {
            if (!request.QueryString.TryGetValue("eventType".ToLowerInvariant(), out var eventType)) return;
            switch (eventType.ToLowerInvariant())
            {
                case "onkeydown":
                    CallOnKeyDown(request);
                    break;
                case "onkeypress":
                    CallOnKeyPress(request);
                    break;
                case "onkeyup":
                    CallOnKeyUp(request);
                    break;
                case "onclick":
                    CallOnClick(request);
                    break;
                case "ondbclick":
                    CallOnDbClick(request);
                    break;
                case "onmousedown":
                    CallOnMouseDown(request);
                    break;
                case "onmousemove":
                    CallOnMouseMove(request);
                    break;
                case "onmouseout":
                    CallOnMouseOut(request);
                    break;
                case "onmouseover":
                    CallOnMouseOver(request);
                    break;
                case "onmouseup":
                    CallOnMouseUp(request);
                    break;
                case "onwheel":
                    CallOnWheel(request);
                    break;
                default:
                    PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Cannot detect event type: " + eventType);
                    break;
            }
        }
    }
}
