using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProjectOne
{
    [Serializable]
    [DataContract(Name = "PoUser", Namespace = "ProjectOne")]
    public partial class PoUser : PoManagedItem
    {
        [DataMember]
        public string Password;
    }
}
