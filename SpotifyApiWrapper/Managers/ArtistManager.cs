﻿using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using System.Text.Json;

namespace SpotifyApiWrapper.Managers
{
    public class ArtistManager : IArtistManager
    {
        private readonly ITokenManager _tokenManager;

        public ArtistManager(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<Artist> GetArtist(string artistId)
        {
            var artist = new Artist();
            var token = await _tokenManager.GetToken();

            try
            {
                var response = await ApiHelper.GetAsync(token, SpotifyUrls.Artist(artistId));

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    artist = JsonSerializer.Deserialize<Artist>(jsonResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return artist;

        }


        //GetArtistAlbums
        public async Task<Paging<Album>> GetArtistAlbums(string artistId, ArtistAlbumRequest request)
        {
            var albums = new Paging<Album>();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.ArtistAlbums(artistId);


                url = ApiHelper.AddParameter(url, "limit", request.Limit.ToString());
                url = ApiHelper.AddParameter(url, "offset", request.Offset.ToString());

                if (request.IncludeGroups != null)
                {
                    url = ApiHelper.AddParameter(url, "include_groups", request.IncludeGroups);
                }
                if (request.Market != null)
                {
                    url =ApiHelper.AddParameter(url, "market", request.Market);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    albums = JsonSerializer.Deserialize<Paging<Album>>(jsonResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return albums;
        }

        //get artists
        public async Task<ArtistResponse> GetArtists(ArtistRequest request)
        {
            var artists = new ArtistResponse();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.Artists();

                url = ApiHelper.AddParameterFromList(url, "ids", request.Ids);

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    artists = JsonSerializer.Deserialize<ArtistResponse>(jsonResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return artists;
        }

        //GetArtistsTopTracks
        public async Task<TracksResponse> GetArtistsTopTracks(string artistId, string market)
        {
            var topTracks = new TracksResponse();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.ArtistTopTracks(artistId);

                url = ApiHelper.AddParameter(url, "market", market);

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    topTracks = JsonSerializer.Deserialize<TracksResponse>(jsonResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return topTracks;
        }

        //GetArtistsRelatedArtists
        public async Task<ArtistResponse> GetArtistsRelatedArtists(string artistId)
        {
            var relatedArtists = new ArtistResponse();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.ArtistRelatedArtists(artistId);

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    relatedArtists = JsonSerializer.Deserialize<ArtistResponse>(jsonResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return relatedArtists;
        }
    }
}
