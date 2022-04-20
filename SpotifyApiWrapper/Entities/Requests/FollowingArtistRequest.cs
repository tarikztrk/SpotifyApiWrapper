namespace SpotifyApiWrapper.Entities.Requests
{
    public class FollowingArtistRequest
    {
        public string Type { get; set; }
        public string After { get; set; }
        public int Limit { get; set; }
    }
}
