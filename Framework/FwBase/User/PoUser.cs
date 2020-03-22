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
        public string Domain;

        public string Username
        {
            set { Name = value; }
            get { return Name; }
        }

        [DataMember]
        public string Password;

        private string _usernameWithDomain;
        public string UsernameWithDomain
        {
            get
            {
                if (string.IsNullOrEmpty(_usernameWithDomain))
                    _usernameWithDomain = Username + "@" + Domain;
                return _usernameWithDomain;
            }
        }

        public bool IsAuthenticated
        {
            get { return Username != null; }
        }
    }
}
