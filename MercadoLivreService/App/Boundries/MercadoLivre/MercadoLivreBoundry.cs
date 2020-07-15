﻿using MercadoLivreService.App.Boundries.MercadoLivreAdapters;
using MercadoLivreService.App.Boundries.MercadoLivreModels;
using MercadoLivreService.App.Models;
using MercadoLivreService.MercadoLivreModels.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries
{
    public class MercadoLivreBoundry
    {
        public static async Task<AuthCodeExchangeResult> ExchangeAuthorizationCodeForAccessTokens(string code)
        {
            try
            {
                var json = await MercadoLivreLib.ExchangeCodeForTokens(code);
                return AuthCodeExchangeJsonAdapter.Adapt(json);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<AccountTokens> RefreshTokens(string refreshToken)
        {
            try
            {
                var json = await MercadoLivreLib.RefreshTokens(refreshToken);
                return AccessTokensJsonAdapter.AdaptToAccountTokens(json);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ApiCallResponse> SearchRecentOrdersAsync(MercadoLivreBoundryCall _call)
        {
            try
            {
                var call = MercadoLivreBoundryCallAdapter.AdaptToSearchOrdersApiCall(_call);
                return await MercadoLivreLib.SearchRecentOrdersAsync(call);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> ValidateAccessToken(string accessToken)
        {
            try
            {
                var apiCallResponse = await MercadoLivreLib.GetUserData(accessToken);
                var isOk = apiCallResponse.IsDeserializedWithDataModel;
                var hasError = apiCallResponse.HasDeserializationException;

                if (hasError)
                {
                    throw apiCallResponse.DeserializationException;
                }

                return isOk;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ApiCallResponse> GetUserData(string accessToken)
        {
            try
            {
                return await MercadoLivreLib.GetUserData(accessToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
