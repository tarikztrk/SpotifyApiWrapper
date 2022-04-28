using SpotifyApiWrapper.Entities;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface IPlaylistManager
    {
        Task<Playlists> GetPlaylist(string playlistId, string market, string fields);
        Task<List<Image>> GetPlaylistImages(string playlistId);
    }
}