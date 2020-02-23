using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    partial class PoUIComponent<T>
    {
        public PoUIComponent<T> AddClass(string className)
        {
            if (HasClass(className)) return this;
            Model.Class = string.Join(' ', Model.Class ?? string.Empty, className).Trim();
            return this;
        }

        public void RemoveClass(string className)
        {
            if (!HasClass(className)) return;
            var classes = Model.Class
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Except(new[] { className });
            Model.Class = string.Join(' ', classes);
        }

        public bool HasClass(string className)
        {
            if (string.IsNullOrWhiteSpace(Model.Class)) return false;
            var classFound = Model.Class
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(x => x == className);
            var ret = classFound != null;
            return ret;
        }
    }
}
