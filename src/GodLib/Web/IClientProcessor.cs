using System.Net;

namespace GodLib.Web
{
    public interface IClientProcessor
    {
        void Process(HttpListenerContext context);
    }
}