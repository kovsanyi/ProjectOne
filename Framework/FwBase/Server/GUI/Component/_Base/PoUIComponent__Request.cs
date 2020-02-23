using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIComponent
    {
        public void Index(PoHttpRequest request)
        {
            try
            {
                Index2(request);
                var children = new Dictionary<string, PoUIComponent>();
                IndexChildren(ref children);
                foreach (var child in children)
                {
                    Index2(request);
                }
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, e.Message);
            }
        }

        public virtual void Index2(PoHttpRequest request) { }

        public void OnClientAction(PoHttpRequest request)
        {
            if (!request.QueryString.TryGetValue("ca", out var clientAction)) return;
            if (string.Equals(clientAction, "invokeEvent", StringComparison.InvariantCultureIgnoreCase))
            {
                Script.HandleRequest(request);
                return;
            }
            OnClientActionReceived(request);
        }

        protected virtual void OnClientActionReceived(PoHttpRequest request) { }
    }
}
