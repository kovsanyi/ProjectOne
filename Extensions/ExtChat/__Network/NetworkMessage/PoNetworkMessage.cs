using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace ProjectOne
{
    public class PoNetworkMessage
    {
        public PoNetworkMessageCommands Command { get; set; }

        public string Content { get; set; }

        public bool TryGetContent<T>(out T content)
        {
            try
            {
                content = JsonSerializer.Deserialize<T>(Content);
                return true;
            }
            catch (Exception e)
            {
                PoLogger.LogException(PoLogSource.Default, e, "Cannot deserialize content.");
                content = default;
                return false;
            }
        }
    }
}
