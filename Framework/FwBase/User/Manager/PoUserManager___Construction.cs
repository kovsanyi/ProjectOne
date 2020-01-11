using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoUserManager
    {
        static PoUserManager _instance;
        static readonly object _sync = new object();

        public static PoUserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new PoUserManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private PoUserManager()
        {
            MakePersistence("Users");
        }

        protected override void OnCreated()
        {
            var admin = new PoUser();
            admin.Name = "admin";
            admin.Password = "admin";
            Add(admin);
            base.OnCreated();
        }
    }
}
