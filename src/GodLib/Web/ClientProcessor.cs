using System.IO;
using System.Net;
using System.Text;
using GodLib.Adapters;

namespace GodLib.Web
{
    public class ClientProcessor : BaseClientProcessor
    {
        private string _lastAnswer = string.Empty;

        public void GetAnswer(HttpListenerContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.OK;
            var bytes = Encoding.UTF8.GetBytes(_lastAnswer);
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            Send(context);
        }

        public void PostInputData(HttpListenerContext context)
        {
            if (context.Request.HttpMethod != "POST")
            {
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                _lastAnswer = null;
                return;
            }

            string data;
            using (var streamReader = new StreamReader(context.Request.InputStream))
            {
                data = streamReader.ReadToEnd();
            }
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            Send(context);

            var adapter = new JsonIOAdapter(new IOAdapter());
            _lastAnswer = adapter.Convert(data);
        }

        public void Ping(HttpListenerContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.OK;
            Send(context);
        }
    }
}