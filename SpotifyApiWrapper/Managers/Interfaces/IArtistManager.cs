using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface IArtistManager
    {
        Task<Artist> GetArtist(string artistId);
        Task<Paging<Album>> GetArtistAlbums(string artistId, ArtistAlbumRequest request);
        Task<ArtistResponse> GetArtists(ArtistRequest request);
        Task<TracksResponse> GetArtistsTopTracks(string artistId, string market);
        Task<ArtistResponse> GetArtistsRelatedArtists(string artistId);
    }
}