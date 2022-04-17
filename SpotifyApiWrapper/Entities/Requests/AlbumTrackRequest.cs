namespace SpotifyApiWrapper.Entities.Requests
{
    public class AlbumTrackRequest
    {
        public string? Market { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
