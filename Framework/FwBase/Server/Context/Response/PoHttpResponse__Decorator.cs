﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ProjectOne
{
    partial class PoHttpResponse
    {
        public void Dispose()
        {
            ((IDisposable)_response).Dispose();
        }

        public void Abort()
        {
            _response.Abort();
        }

        public void AddHeader(string name, string value)
        {
            _response.AddHeader(name, value);
        }

        public void AppendCookie(Cookie cookie)
        {
            _response.AppendCookie(cookie);
        }

        public void AppendHeader(string name, string value)
        {
            _response.AppendHeader(name, value);
        }

        public void Close()
        {
            _response.Close();
        }

        public void Close(byte[] responseEntity, bool willBlock)
        {
            _response.Close(responseEntity, willBlock);
        }

        public void CopyFrom(HttpListenerResponse templateResponse)
        {
            _response.CopyFrom(templateResponse);
        }

        public void Redirect(string url)
        {
            _response.Redirect(url);
        }

        public void SetCookie(Cookie cookie)
        {
            _response.SetCookie(cookie);
        }

        public Encoding ContentEncoding
        {
            get => _response.ContentEncoding;
            set => _response.ContentEncoding = value;
        }

        public long ContentLength64
        {
            get => _response.ContentLength64;
            set => _response.ContentLength64 = value;
        }

        public string ContentType
        {
            get => _response.ContentType;
            set => _response.ContentType = value;
        }

        public CookieCollection Cookies
        {
            get => _response.Cookies;
            set => _response.Cookies = value;
        }

        public WebHeaderCollection Headers
        {
            get => _response.Headers;
            set => _response.Headers = value;
        }

        public bool KeepAlive
        {
            get => _response.KeepAlive;
            set => _response.KeepAlive = value;
        }

        public Stream OutputStream => _response.OutputStream;

        public Version ProtocolVersion
        {
            get => _response.ProtocolVersion;
            set => _response.ProtocolVersion = value;
        }

        public string RedirectLocation
        {
            get => _response.RedirectLocation;
            set => _response.RedirectLocation = value;
        }

        public bool SendChunked
        {
            get => _response.SendChunked;
            set => _response.SendChunked = value;
        }

        public int StatusCode
        {
            get => _response.StatusCode;
            set => _response.StatusCode = value;
        }

        public string StatusDescription
        {
            get => _response.StatusDescription;
            set => _response.StatusDescription = value;
        }
    }
}
