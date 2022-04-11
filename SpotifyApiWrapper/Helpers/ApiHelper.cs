using System.Net;

namespace SpotifyApiWrapper.Helpers{
    public static class ApiHelper{
        public static string GetApiUrl(string url){
            return $"https://api.spotify.com/v1/{url}";
        }

        public static HttpWebRequest CreateRequest(Uri uri){
            var request = WebRequest.CreateHttp(uri);
            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", $"Bearer {SpotifyApi.AccessToken}");
            return request;
        }

        
    }
}