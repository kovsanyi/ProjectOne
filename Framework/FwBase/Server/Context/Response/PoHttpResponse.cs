using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjectOne
{
    public partial class PoHttpResponse
    {
        private readonly HttpListenerResponse _response;

        public PoHttpResponse(HttpListenerResponse response)
        {
            _response = response;
        }

        public void SetContentType(string contentType)
        {
            _response.ContentType = contentType;
        }

        public void WriteStringToOutput(string data)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            WriteBytesToOutput(dataBytes);
        }

        public void WriteBytesToOutput(byte[] data)
        {
            try
            {
                _response.OutputStream.Write(data, 0, data.Length);
            }
            catch (ObjectDisposedException)
            {
                PoLogger.Log(PoLogSource.Default, PoLogType.Error,
                    "Cannot write data to output due to closed connection."
                    + Environment.NewLine + Environment.StackTrace);
            }
            catch (Exception e)
            {
                PoLogger.LogException(PoLogSource.Default, e);
            }
        }

        public void SendSuccess()
        {
            CloseRequest(HttpStatusCode.OK);
        }

        public void SendRedirect()
        {
            CloseRequest(HttpStatusCode.Redirect);
        }

        public void SendNotFound()
        {
            CloseRequest(HttpStatusCode.NotFound);
        }

        public void SendUnauthorized()
        {
            CloseRequest(HttpStatusCode.Unauthorized);
        }

        private void CloseRequest(HttpStatusCode statusCode)
        {
            try
            {
                _response.StatusCode = (int)statusCode;
                _response.StatusDescription = nameof(statusCode);
                _response.Close();
            }
            catch (Exception e)
            {
                PoLogger.LogException(PoLogSource.Default, e, "Error while closing connection.");
            }
        }
    }
}
