using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUILayout
    {
        public override void IndexChildren(ref Dictionary<string, PoUIComponent> children)
        {
            lock (_sync)
            {
                foreach (var child in this)
                {
                    if (children.TryAdd(child.ID, child)) continue;
                    PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                        $"Cannot index child {child.GetType()} {child.ID} of {GetType()} {ID}. ID already exists in chain.");
                }

                foreach (var child in this)
                {
                    child.IndexChildren(ref children);
                }
            }
        }
    }
}
