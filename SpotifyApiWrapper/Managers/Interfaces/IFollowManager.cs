using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface IFollowManager
    {
        Task<FollowingArtistResponse> FollowingArtist(FollowingArtistRequest request);
    }
}