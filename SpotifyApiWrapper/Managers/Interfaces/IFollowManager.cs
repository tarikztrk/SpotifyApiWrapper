using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface IFollowManager
    {
        Task<List<bool>> CheckUserFollowPlaylist(string playlist_id, string ids);
    }
}