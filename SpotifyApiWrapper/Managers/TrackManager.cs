using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.AudioAnalysis;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using System.Text.Json;

namespace SpotifyApiWrapper.Managers
{
    public class TrackManager : ITrackManager
    {
        private readonly ITokenManager _tokenManager;

        public TrackManager(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<Entities.Track> GetTrack(string trackId,string market)
        {
            var track = new Entities.Track();
            var token = await _tokenManager.GetToken();
            try
            {
                var url = SpotifyUrls.Track(trackId);
                if (!string.IsNullOrEmpty(market))
                {
                    url = ApiHelper.AddParameter(url, "market", market);
                }
                    
                var response = await ApiHelper.GetAsync(token,url );

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    track = JsonSerializer.Deserialize<Entities.Track>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return track;
        }
        
        public async Task<TracksResponse> GetTracks(string ids,string market)
        {
            var tracks = new TracksResponse();
            var token = await _tokenManager.GetToken();
            try
            {
                var url = SpotifyUrls.Tracks();
                if (!string.IsNullOrEmpty(ids))
                {
                    url = ApiHelper.AddParameter(url, "ids", ids);
                }
               
                if (!string.IsNullOrEmpty(market))
                {
                    url = ApiHelper.AddParameter(url, "market", market);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    tracks = JsonSerializer.Deserialize<TracksResponse>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return tracks;
        }


        //GetAudioFeatures
        public async Task<AudioFeatures> GetAudioFeatures(string trackId)
        {
            var audioFeatures = new AudioFeatures();
            var token = await _tokenManager.GetToken();
            try
            {
                var url = SpotifyUrls.AudioFeatures(trackId);
                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    audioFeatures = JsonSerializer.Deserialize<AudioFeatures>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return audioFeatures;
        }

        //GetAudiosFeatures
        public async Task<AudioFeaturesResponse> GetAudiosFeatures(string ids)
        {
            var audioFeatures = new AudioFeaturesResponse();
            var token = await _tokenManager.GetToken();
            try
            {
                var url = SpotifyUrls.AudioFeatures();
                if (!string.IsNullOrEmpty(ids))
                {
                    url = ApiHelper.AddParameter(url, "ids", ids);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    audioFeatures = JsonSerializer.Deserialize<AudioFeaturesResponse>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return audioFeatures;
        }


        //GetAudioAnalysis
        public async Task<AudioAnalysis> GetAudioAnalysis(string trackId)
        {
            var audioAnalysis = new AudioAnalysis();
            var token = await _tokenManager.GetToken();
            try
            {
                var url = SpotifyUrls.AudioAnalysis(trackId);
                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    audioAnalysis = JsonSerializer.Deserialize<AudioAnalysis>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return audioAnalysis;
        }

    }
}
