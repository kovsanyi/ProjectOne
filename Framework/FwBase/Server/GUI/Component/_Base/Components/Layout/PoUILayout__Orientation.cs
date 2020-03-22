using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUILayout
    {
        private const string OrientationVertical = "div-vertical";
        private const string OrientationHorizontal = "div-horizontal";

        private PoOrientationType _orientation;
        public PoOrientationType Orientation
        {
            get => _orientation;
            set
            {
                //if (_orientation == value) return;
                switch (value)
                {
                    case PoOrientationType.Vertical:
                        RemoveClass(OrientationHorizontal);
                        break;
                    default:
                        RemoveClass(OrientationVertical);
                        AddClass(OrientationHorizontal);
                        break;
                }
                _orientation = value;
                Refresh();
            }
        }

        //protected void AddClassToChildren(string cssClass)
        //{
        //    if (_items == null || _items.Count == 0) return;
        //    foreach (var item in _items)
        //    {
        //        if (!(item is PoUIComponent<PoUIModel> c)) continue;
        //        c.AddClass(cssClass);
        //    }
        //}

        //protected void RemoveClassFromChildren(string cssClass)
        //{
        //    if (_items == null || _items.Count == 0) return;
        //    foreach (var item in _items)
        //    {
        //        if (!(item is PoUIComponent<PoUIModel> c)) continue;
        //        c.RemoveClass(cssClass);
        //    }
        //}

        //private void AddRelevantOrientationClassToChild(PoUIComponent<PoUIModel> c)
        //{
        //    switch (_orientation)
        //    {
        //        case PoOrientationType.Vertical:
        //            c.RemoveClass(OrientationHorizontal);
        //            c.AddClass(OrientationVertical);
        //            break;
        //        default:
        //            c.RemoveClass(OrientationVertical);
        //            c.AddClass(OrientationHorizontal);
        //            break;
        //    }
        //}
    }
}
