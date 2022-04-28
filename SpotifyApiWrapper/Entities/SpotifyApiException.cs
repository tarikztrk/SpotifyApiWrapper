using System.Net;

namespace SpotifyApiWrapper.Entities
{
    public class SpotifyApiException : Exception
    {
        public SpotifyApiException()
        {

        }

        public SpotifyApiException(string code, HttpStatusCode statusCode)
        {
            this.Code = code;
            this.StatusCode = statusCode;
        }

        public string Code { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
