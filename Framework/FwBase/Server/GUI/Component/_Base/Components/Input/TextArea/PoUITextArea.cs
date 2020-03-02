using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUITextArea : PoUIComponent<PoUIModelTextArea>
    {
        public PoUITextArea() : base()
        {
            Script.InitScript(PoUIEventType.OnBlur);
            Script.OnBlur += Script_OnBlur;
        }

        private void Script_OnBlur(object sender, PoHttpRequest req)
        {
            if (!req.QueryString.TryGetValue("SenderValue".ToLowerInvariant(), out var senderValue)) return;
            Value = senderValue;
        }

        protected override void DisposeContent()
        {
            Script.OnBlur -= Script_OnBlur;
        }
    }
}
