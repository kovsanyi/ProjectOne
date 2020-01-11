using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUIModel
    {
        public string Model
        {
            get
            {
                var ret = CreateModel();
                return ret;
            }
        }

        public virtual string CreateModel()
        {
            var attributes = CreateAttributes();
            var eventAttributes = string.Empty;
            if (Events != null) eventAttributes = Events.CreateScipts();
            var ret = $"<{Tag ?? ""}{attributes}{eventAttributes}>{ValueBetweenTags ?? ""}</{Tag ?? ""}>";
            return ret;
        }
    }
}
