using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyApiWrapper.Entities;

namespace SpotifyApiWrapper.Authentication
{
    public static class ClientCredentials
    {
        public static string ClientId = "";
        public static string ClientSecret = "";

        public static string GetAuthorizationHeader()
        {
            return $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}"))}";
        }

        //get the access token
        public async static Task<Token> GetToken()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {

            { "client_id", "3857882ba2e9439ebd7066d97dc6203d" },
            { "client_secret", "921d5dfb5b8840839f6e25ba3090c0d8" },
            { "grant_type", "client_credentials" }
            });

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
            var token = new Token
            {
                AccessToken = payload.Value<string>("access_token"),
                ExpiresIn = payload.Value<int>("expires_in"),
                TokenType = payload.Value<string>("token_type")
            };

            return token;
        }


    }
}