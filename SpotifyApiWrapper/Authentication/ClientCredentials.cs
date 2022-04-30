using System.Net;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyApiWrapper.Entities;

namespace SpotifyApiWrapper.Authentication
{
    public class ClientCredentials : IClientCredentials
    {
        private readonly HttpClient _httpClient;

        public ClientCredentials(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetAuthorizationHeader()
        {
            return $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"3857882ba2e9439ebd7066d97dc6203d:e93d3b732f4d4ec789b79b30fe6cda3e"))}";
        }

        //get the access token
        public async Task<Token> GetToken(AuthParameters parameters)
        {
            var token = new Token();
            try
            {
                var url = SpotifyUrls.OAuthToken;
                var request = WebRequest.CreateHttp(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Authorization", GetAuthorizationHeader());
                var body = $"grant_type={parameters.GrantType}&client_id={parameters.ClientId}&client_secret={parameters.ClientSecret}&redirect_uri={parameters.RedirectUri}";
                var bodyBytes = Encoding.UTF8.GetBytes(body);
                request.ContentLength = bodyBytes.Length;
                
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bodyBytes, 0, bodyBytes.Length);
                }
                
                var response = await request.GetResponseAsync();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var parsedResponse = JObject.Parse(responseString);
                
                token = new Token
                {
                    AccessToken = parsedResponse.Value<string>("access_token"),
                    ExpiresIn = parsedResponse.Value<int>("expires_in"),
                    TokenType = parsedResponse.Value<string>("token_type")
                };
                
                return token;
            }
            catch (Exception)
            {
                throw new SpotifyApiException("Error getting token", HttpStatusCode.Unauthorized);
            }
        }



    }
}