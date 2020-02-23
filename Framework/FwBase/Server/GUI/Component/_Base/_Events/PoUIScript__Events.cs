using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIScript
    {
        public event EventHandler OnKeyDown;
        private void CallOnKeyDown(PoHttpRequest request)
        {
            OnKeyDown?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnKeyPress;
        private void CallOnKeyPress(PoHttpRequest request)
        {
            OnKeyPress?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnKeyUp;
        private void CallOnKeyUp(PoHttpRequest request)
        {
            OnKeyUp?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnClick;
        private void CallOnClick(PoHttpRequest request)
        {
            OnClick?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnDbClick;
        private void CallOnDbClick(PoHttpRequest request)
        {
            OnDbClick?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnMouseDown;
        private void CallOnMouseDown(PoHttpRequest request)
        {
            OnMouseDown?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnMouseMove;
        private void CallOnMouseMove(PoHttpRequest request)
        {
            OnMouseMove?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnMouseOut;
        private void CallOnMouseOut(PoHttpRequest request)
        {
            OnMouseOut?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnMouseOver;
        private void CallOnMouseOver(PoHttpRequest request)
        {
            OnMouseOver?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnMouseUp;
        private void CallOnMouseUp(PoHttpRequest request)
        {
            OnMouseUp?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler OnWheel;
        private void CallOnWheel(PoHttpRequest request)
        {
            OnWheel?.Invoke(null, EventArgs.Empty);
        }
    }
}
