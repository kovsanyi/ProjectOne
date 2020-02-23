using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    public class PoUIStyle
    {
        private readonly Dictionary<string, string> _style = new Dictionary<string, string>();

        public PoUIStyle() { }

        public void SetStyle(string name, string value)
        {
            _style.Remove(name);
            _style.TryAdd(name.TrimEnd(';'), value);
        }

        public void ClearStyle()
        {
            _style.Clear();
        }

        public virtual string CreateStyle()
        {
            var sb = new StringBuilder();
            foreach (var cssEntry in _style)
            {
                sb.Append($"{cssEntry.Key}:{cssEntry.Value};");
            }

            return sb.ToString();
        }
    }
}