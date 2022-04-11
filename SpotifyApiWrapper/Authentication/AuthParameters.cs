namespace SpotifyApiWrapper.Authentication
{
    public class AuthParameters
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? RedirectUri { get; set; }
        public string? Scope { get; set; }
        public string? GrantType { get; set; }
    }
}