using System.Xml.Serialization;

namespace GodLib.Web
{
    public interface IHttpServer
    {
        void Start();
        void Stop();
    }
}