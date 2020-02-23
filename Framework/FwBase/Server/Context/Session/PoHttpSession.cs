using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Reflection.Metadata;
using System.Text;

namespace ProjectOne
{
    public class PoHttpSession : PoManagedItem
    {
        public readonly string UserAgent;
        public readonly string RemoteIP;
        public readonly string RemoteEndPoint;
        public DateTime LastVisited;
        public string Username;

        public bool IsAuthenticated => Username == null;

        public PoHttpSession() { }

        public PoHttpSession(string userAgent, string remoteEndPoint)
        {
            UserAgent = userAgent;
            RemoteIP = remoteEndPoint.Substring(0, remoteEndPoint.IndexOf(':'));
            RemoteEndPoint = remoteEndPoint;
            LastVisited = DateTime.Now;
        }

        public void VisitNow()
        {
            LastVisited = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{RemoteEndPoint} {UserAgent} {LastVisited.ToString(CultureInfo.InvariantCulture)} Username: {Username ?? "guest"}";
        }
    }
}
