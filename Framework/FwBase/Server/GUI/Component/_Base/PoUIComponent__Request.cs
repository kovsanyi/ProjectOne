using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

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
                    child.Value.Index2(request);
                }
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error, e.Message);
            }
        }

        public virtual void Index2(PoHttpRequest request)
        {
            OnClientAction(request);
        }

        public void OnClientAction(PoHttpRequest request)
        {
            if (!request.QueryString.TryGetValue("ClientAction", out var clientAction)) return;
            if (!request.QueryString.TryGetValue("SenderId", out var senderId)) return;
            if (!ID.Equals(senderId, StringComparison.InvariantCultureIgnoreCase)) return;
            if (string.Equals(clientAction, "invokeEvent", StringComparison.InvariantCultureIgnoreCase))
            {
                Script.HandleRequest(request);
                return;
            }
            OnClientActionReceived(request);
        }

        protected virtual void OnClientActionReceived(PoHttpRequest request) { }

        public string GetModificationsAsJson(DateTime lastSeen)
        {
            var children = new Dictionary<string, PoUIComponent>();
            IndexChildren(ref children);

            var response = new PoUIResponseData()
            {
                Modified = true,
                SenderId = "asd"
            };
            foreach (var child in children)
            {
                var isModified = child.Value.LastUpdated > lastSeen;
                if (!isModified) continue;
                response.Elements.Add(
                    new PoUIResponseDataElement()
                    {
                        ComponentId = child.Key,
                        HtmlContent = child.Value.ToHtml()
                    });
            }

            var responseJson = JsonSerializer.Serialize<PoUIResponseData>(response);
            return responseJson;
        }
    }
}
