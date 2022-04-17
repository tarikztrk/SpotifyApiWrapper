namespace SpotifyApiWrapper.Entities.Requests
{
    public class ArtistAlbumRequest
    {
        public string? Market { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string? IncludeGroups { get; set; }
    }
}
