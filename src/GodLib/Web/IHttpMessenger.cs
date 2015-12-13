using GodLib.Entities;

namespace GodLib.Web
{
    public interface IHttpMessenger
    {
        Response SendGet(string method);
        Response SendPost(string method, byte[] request);
    }
}