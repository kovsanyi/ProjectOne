using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace ProjectOne
{
    [Serializable]
    [DataContract(Name = "PoManagedItem", Namespace = "ProjectOne")]
    public partial class PoManagedItem
    {
        string _ID;
        [DataMember]
        public virtual string ID
        {
            get { return _ID ?? GenerateID(); }
            set { _ID = value; }
        }

        string _name;
        [DataMember]
        public virtual string Name
        {
            get { return _name ?? ID; }
            set { _name = value; }
        }

        protected virtual string GenerateID()
        {
            _ID = PoCommonStrings.GenerateRandomStr();
            return _ID;
        }
    }
}
