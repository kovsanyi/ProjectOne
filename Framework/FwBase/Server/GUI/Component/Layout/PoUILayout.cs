using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    public partial class PoUILayout : PoUIComponent
    {
        List<PoUIComponent> _items;

        public PoUILayout()
        {
            Model = new PoUIModel();
            Model.Tag = "div";
            _items = new List<PoUIComponent>();
        }
    }
}
