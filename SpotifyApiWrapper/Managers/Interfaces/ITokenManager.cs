﻿using SpotifyApiWrapper.Entities;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface ITokenManager
    {
        Task<Token> GetToken();
    }
}