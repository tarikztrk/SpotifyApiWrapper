﻿using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using System.Text.Json;

namespace SpotifyApiWrapper.Managers
{
    public class FollowManager : IFollowManager
    {
        private readonly ITokenManager _tokenManager;

        public FollowManager(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<List<bool>> CheckUserFollowPlaylist(string playlist_id,  string ids)
        {
            var retVal = new List<bool>();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.PlaylistFollowersContains(playlist_id);

                if (ids != null)
                {
                    url = url.AddParameter("ids", ids);
                }
               

                var response = await ApiHelper.GetAsync(token, url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    retVal = JsonSerializer.Deserialize<List<bool>>(jsonResponse);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new SpotifyApiException("User following playlist not found", response.StatusCode);
                }
                else
                {
                    throw new SpotifyApiException("Something got wrong.", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                if (ex is SpotifyApiException)
                {
                    throw;
                }
                throw new Exception();
            }


            return retVal;
        }
    }
}
