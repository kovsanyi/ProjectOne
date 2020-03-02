using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoItemManager<T>
    {
        public event EventHandler<T> OnItemAdded;

        protected void CallOnItemAdded(T item)
        {
            OnItemAdded?.Invoke(this, item);
        }

        public event EventHandler<T> OnItemUpdated;
        protected void CallOnItemUpdated(T item)
        {
            OnItemUpdated?.Invoke(this, item);
        }

        public event EventHandler<T> OnItemDeleted;
        protected void CallOnItemDeleted(T item)
        {
            OnItemDeleted?.Invoke(this, item);
        }
    }
}
