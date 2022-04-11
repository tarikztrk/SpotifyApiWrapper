using SpotifyApiWrapper.Entities;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface IAlbumManager
    {
        Task<Album> GetAlbumAsync(string albumId);
    }
}