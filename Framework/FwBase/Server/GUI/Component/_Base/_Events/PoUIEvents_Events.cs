using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIEvents
    {
        //Keyboard events
        public event EventHandler OnKeyDown;
        public event EventHandler OnKeyPress;
        public event EventHandler OnKeyUp;

        //Mouse events
        public event EventHandler OnClick;
        public event EventHandler OnDbClick;
        public event EventHandler OnMouseDown;
        public event EventHandler OnMouseMove;
        public event EventHandler OnMouseOut;
        public event EventHandler OnMouseOver;
        public event EventHandler OnMouseUp;
        public event EventHandler OnWheel;
    }
}
