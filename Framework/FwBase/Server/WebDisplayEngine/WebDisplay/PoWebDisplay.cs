//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ProjectOne
//{
//    public partial class PoWebDisplay
//    {
//        private bool _underProgress = false;
//        private readonly object _sync = new object();
//        private readonly Dictionary<string, PoUIComponent> _componentsOnDisplay;

//        public PoWebDisplay()
//        {
//            _componentsOnDisplay = new Dictionary<string, PoUIComponent>();
//        }

//        public void ProcessDisplayRequest(PoHttpContext context, IPoWebDisplayRequest displayRequest)
//        {
//            if (_underProgress) PoLogger.Log(PoLogSource.Default, PoLogType.Warn,
//                $"Waiting for processing HTTP request. {displayRequest.GetType().Name}");
//            lock (_sync)
//            {
//                _underProgress = true;
//                try
//                {
//                    foreach (var component in _componentsOnDisplay)
//                        component.Value.Index(context);
//                    displayRequest.Process(context, _componentsOnDisplay);
//                }
//                catch (Exception e)
//                {
//                    PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Error while processing '{displayRequest.GetType().Name}' request. {e.Message}");
//                }
//                _underProgress = false;
//            }
//        }

//        public void Dispose()
//        {
//            foreach (var appComponent in _componentsOnDisplay.Values)
//                appComponent.Dispose();
//        }
//    }
//}
