using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.AudioAnalysis;
using SpotifyApiWrapper.Entities.Response;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface ITrackManager
    {
        Task<Track> GetTrack(string trackId, string market);
        Task<TracksResponse> GetTracks(string ids, string market);
        Task<AudioFeatures> GetAudioFeatures(string trackId);
        Task<AudioFeaturesResponse> GetAudiosFeatures(string trackId);
        Task<AudioAnalysis> GetAudioAnalysis(string trackId);
    }
}