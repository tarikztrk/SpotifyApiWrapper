using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface IAlbumManager
    {
        Task<Album> GetAlbumById(string id,AlbumRequest request);
        Task<AlbumsResponse> GetSeveralAlbums(SeveralAlbumRequest request);
        Task<Paging<Track>> GetAlbumTracks(string id, AlbumTrackRequest request);
    }
}