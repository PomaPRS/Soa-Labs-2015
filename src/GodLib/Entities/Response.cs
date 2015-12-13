using System.Net;

namespace GodLib.Entities
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Data { get; set; }
    }
}