using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectOne
{
    partial class PoRequestFilter
    {
        protected void LoadFilters()
        {
            var ti = typeof(IPoRequestFilter);
            var tc = GetType();
            var filterTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && x != tc && ti.IsAssignableFrom(x));
            foreach (var filterT in filterTypes)
                RegisterFilter(filterT);
        }

        protected void RegisterFilter(Type filterType)
        {
            try
            {
                var filterObj = (IPoRequestFilter)Activator.CreateInstance(filterType);
                Filters.Add(filterObj);
            }
            catch (Exception e)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                    "Could not instantiate request filer: " + filterType.Name + ". Exception: " + e.Message);
            }
        }
    }
}
