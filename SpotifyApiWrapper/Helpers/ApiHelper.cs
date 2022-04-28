using Microsoft.AspNetCore.Authentication;
using SpotifyApiWrapper.Entities;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace SpotifyApiWrapper.Helpers
{

    public static class ApiHelper
    {
        
        /// <summary>Gets an HTTP response from the Spotify API.</summary>
        /// <param name="token">The access token to use for the request.</param>
        /// <param name="url">The URL to request.</param>
        /// <returns>The response from the Spotify API.</returns>
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
        

        /// <summary>Adds a parameter to a URL.</summary>
        /// <param name="url">The URL.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <returns>The URL with the parameter added.</returns>
        public static Uri AddParameter(this Uri url, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        /// <summary>Adds a parameter to a URL.</summary>
        /// <param name="url">The URL to add the parameter to.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="paramValues">The values of the parameter.</param>
        /// <returns>The URL with the parameter added.</returns>
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