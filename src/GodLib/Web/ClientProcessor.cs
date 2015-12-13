using System.IO;
using System.Net;
using System.Text;
using GodLib.Adapters;

namespace GodLib.Web
{
    public class ClientProcessor : IClientProcessor
    {
        private string lastAnswer = string.Empty;

        public void Process(HttpListenerContext context)
        {
            var actionName = context.Request.Url.AbsolutePath.Trim('/');
            switch (actionName)
            {
                case "Ping":
                    ProcessPing(context);
                    break;
                case "PostInputData":
                   lastAnswer = ProcessPostInputData(context);
                    break;
                case "GetAnswer":
                    ProcessGetAnswer(context, lastAnswer);
                    break;
                default:
                    context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    Send(context);
                    break;
            }
        }

        private void ProcessGetAnswer(HttpListenerContext context, string answer)
        {
            context.Response.StatusCode = (int) HttpStatusCode.OK;
            var bytes = Encoding.UTF8.GetBytes(answer);
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            Send(context);
        }

        private string ProcessPostInputData(HttpListenerContext context)
        {
            if (context.Request.HttpMethod != "POST")
            {
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                return null;
            }

            string data;
            using (var streamReader = new StreamReader(context.Request.InputStream))
            {
                data = streamReader.ReadToEnd();
            }
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            Send(context);

            var adapter = new JsonIOAdapter(new IOAdapter());
            return adapter.Convert(data);
        }

        private void ProcessPing(HttpListenerContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.OK;
            Send(context);
        }

        private void Send(HttpListenerContext context)
        {
            context.Response.OutputStream.Close();
        }
    }
}