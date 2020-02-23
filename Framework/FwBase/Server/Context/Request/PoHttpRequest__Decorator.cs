using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    partial class PoHttpRequest
    {
        public IAsyncResult BeginGetClientCertificate(AsyncCallback requestCallback, object state)
        {
            return _request.BeginGetClientCertificate(requestCallback, state);
        }

        public X509Certificate2 EndGetClientCertificate(IAsyncResult asyncResult)
        {
            return _request.EndGetClientCertificate(asyncResult);
        }

        public X509Certificate2 GetClientCertificate()
        {
            return _request.GetClientCertificate();
        }

        public Task<X509Certificate2> GetClientCertificateAsync()
        {
            return _request.GetClientCertificateAsync();
        }

        public string[] AcceptTypes => _request.AcceptTypes;

        public int ClientCertificateError => _request.ClientCertificateError;

        public Encoding ContentEncoding => _request.ContentEncoding;

        public long ContentLength64 => _request.ContentLength64;

        public string ContentType => _request.ContentType;

        public CookieCollection Cookies => _request.Cookies;

        public bool HasEntityBody => _request.HasEntityBody;

        public NameValueCollection Headers => _request.Headers;

        public string HttpMethod => _request.HttpMethod;

        public Stream InputStream => _request.InputStream;

        public bool IsAuthenticated => _request.IsAuthenticated;

        public bool IsLocal => _request.IsLocal;

        public bool IsSecureConnection => _request.IsSecureConnection;

        public bool IsWebSocketRequest => _request.IsWebSocketRequest;

        public bool KeepAlive => _request.KeepAlive;

        public IPEndPoint LocalEndPoint => _request.LocalEndPoint;

        public Version ProtocolVersion => _request.ProtocolVersion;

        //public NameValueCollection QueryString => _request.QueryString;

        public string RawUrl => _request.RawUrl;

        public IPEndPoint RemoteEndPoint => _request.RemoteEndPoint;

        public Guid RequestTraceIdentifier => _request.RequestTraceIdentifier;

        public string ServiceName => _request.ServiceName;

        public TransportContext TransportContext => _request.TransportContext;

        public Uri Url => _request.Url;

        public Uri UrlReferrer => _request.UrlReferrer;

        public string UserAgent => _request.UserAgent;

        public string UserHostAddress => _request.UserHostAddress;

        public string UserHostName => _request.UserHostName;

        public string[] UserLanguages => _request.UserLanguages;
    }
}
