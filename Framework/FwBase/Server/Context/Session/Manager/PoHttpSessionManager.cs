using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ProjectOne
{
    public partial class PoHttpSessionManager : PoItemManager<PoHttpSession>
    {
        private const int SessionCookieLifetimeInMinutes = 60;
        private const string SessionCookie = "ProjectOneSession";

        public void HandleRequest(PoHttpContext context)
        {
            var sessionId = FindOrCreateSession(context);
            var session = GetItems().FirstOrDefault(x => x.ID == sessionId);
            PoSessionContainer.Instance.ProcessRequest(context, sessionId, session);

            session?.VisitNow();
        }

        public string FindOrCreateSession(PoHttpContext context)
        {
            var sessionCookie = GetSessionCookie(context.Request);
            if (sessionCookie == null)
            {
                sessionCookie = CreateSessionCookie(context.Request);
                context.Response.Cookies.Add(sessionCookie);
                return sessionCookie.Value;
            }
            var session = GetItems().FirstOrDefault(x => x.ID == sessionCookie.Value);
            if (session == null)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Session cookie does not exists on server!");
                sessionCookie = CreateSessionCookie(context.Request);
                context.Response.Cookies.Add(sessionCookie);
                return sessionCookie.Value;
            }
            if (!ValidateSessionCookie(context.Request, session))
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Warn, "Session cookie is not valid!");
                Remove(session);
                sessionCookie = CreateSessionCookie(context.Request);
                return sessionCookie.Value;
            }
            //session.VisitNow();
            return session.ID;
        }

        private Cookie CreateSessionCookie(PoHttpRequest request)
        {
            var session = new PoHttpSession(request.UserAgent, request.RemoteEndPoint.ToString());
            Add(session);
            var cookie = new Cookie(SessionCookie, session.ID);
            cookie.Expires = DateTime.Now.AddMinutes(SessionCookieLifetimeInMinutes);
            cookie.Path = "/";
            return cookie;
        }

        private Cookie GetSessionCookie(PoHttpRequest request)
        {
            foreach (Cookie cookie in request.Cookies)
            {
                if (cookie.Name == SessionCookie) return cookie;
            }

            return null;
        }

        private bool ValidateSessionCookie(PoHttpRequest request, PoHttpSession session)
        {
            if (request.RemoteEndPoint.ToString().Substring(0, request.RemoteEndPoint.ToString().IndexOf(':')) != session.RemoteIP) return false;
            if (request.UserAgent != session.UserAgent) return false;
            return true;
        }
    }
}
