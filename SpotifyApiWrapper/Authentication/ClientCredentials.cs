using System.Text;

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
        public static string GetToken(AuthParameters authParameters)
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://accounts.spotify.com/api/token") };

            var token = client.GetStringAsync()

        }


    }

    public class AuthParameters
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? RedirectUri { get; set; }
        public string? Scope { get; set; }
        public string? GrantType { get; set; }
    }
}