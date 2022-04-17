using SpotifyApiWrapper.Entities;
using System.Net;
using System.Net.Http.Headers;
using System.Web;

namespace SpotifyApiWrapper.Helpers
{

    public static class ApiHelper
    {

        public async static Task<HttpResponseMessage> GetAsync(Token token, Uri url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

                    client.BaseAddress = new Uri(SpotifyUrls.APIV1.ToString());
                    var response = await client.GetAsync(url);
                    return response;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        public static Uri AddParameter(this Uri url, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        public static Uri AddParameterFromList(this Uri url, string paramName, List<string> paramValues)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            var paramValue = string.Join(",", paramValues);

            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }



    }
}