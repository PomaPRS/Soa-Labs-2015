using System;
using System.Net;
using System.Net.Sockets;

namespace GodLib.Web
{
    public class HttpServer : IHttpServer
    {
        private readonly HttpListener _listener;
        private readonly IClientProcessor _clientProcessor;

        public HttpServer(string host, int port, IClientProcessor clientProcessor)
        {
            _clientProcessor = clientProcessor;
            _listener = new HttpListener();
            _listener.Prefixes.Add(string.Format("{0}:{1}/", host, port));
        }

        ~HttpServer()
        {
            Stop();
        }

        public void Start()
        {
            _listener.Start();
            while (_listener.IsListening)
            {
                var context = _listener.GetContext();

                try
                {
                    var actionName = context.Request.Url.AbsolutePath.Trim('/');
                    if (actionName == "Stop")
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        context.Response.OutputStream.Close();
                        Stop();
                    }
                    else
                        _clientProcessor.Process(context);
                }
                catch (Exception)
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.OutputStream.Close();
                }
            }
        }

        public void Stop()
        {
            if (_listener != null)
                _listener.Stop();
        }
    }
}