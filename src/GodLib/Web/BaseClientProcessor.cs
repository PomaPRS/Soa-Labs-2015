using System;
using System.Net;

namespace GodLib.Web
{
    public abstract class BaseClientProcessor : IClientProcessor
    {
        public void Process(HttpListenerContext context)
        {
            try
            {
                var actionName = context.Request.Url.AbsolutePath.Trim('/');
                var type = this.GetType();
                var methodInfo = type.GetMethod(actionName);
                methodInfo.Invoke(this, new object[] { context });
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                Send(context);
            }
        }

        protected void Send(HttpListenerContext context)
        {
            context.Response.OutputStream.Close();
        }
    }
}