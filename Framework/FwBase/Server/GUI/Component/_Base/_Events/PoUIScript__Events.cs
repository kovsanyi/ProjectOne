using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIScript
    {
        public event EventHandler<PoHttpRequest> OnKeyDown;
        private void CallOnKeyDown(PoHttpRequest request)
        {
            OnKeyDown?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnKeyPress;
        private void CallOnKeyPress(PoHttpRequest request)
        {
            OnKeyPress?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnKeyUp;
        private void CallOnKeyUp(PoHttpRequest request)
        {
            OnKeyUp?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnClick;
        private void CallOnClick(PoHttpRequest request)
        {
            OnClick?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnDbClick;
        private void CallOnDbClick(PoHttpRequest request)
        {
            OnDbClick?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnMouseDown;
        private void CallOnMouseDown(PoHttpRequest request)
        {
            OnMouseDown?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnMouseMove;
        private void CallOnMouseMove(PoHttpRequest request)
        {
            OnMouseMove?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnMouseOut;
        private void CallOnMouseOut(PoHttpRequest request)
        {
            OnMouseOut?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnMouseOver;
        private void CallOnMouseOver(PoHttpRequest request)
        {
            OnMouseOver?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnMouseUp;
        private void CallOnMouseUp(PoHttpRequest request)
        {
            OnMouseUp?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnWheel;
        private void CallOnWheel(PoHttpRequest request)
        {
            OnWheel?.Invoke(_component, request);
        }

        public event EventHandler<PoHttpRequest> OnBlur;
        private void CallOnBlur(PoHttpRequest request)
        {
            OnBlur?.Invoke(_component, request);
        }
    }
}
