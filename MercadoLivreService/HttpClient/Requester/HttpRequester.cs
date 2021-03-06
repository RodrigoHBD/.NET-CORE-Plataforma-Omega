﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class HttpRequester
    {
        public static async Task<HttpResponseMessage> GetAsync(GetRequest request)
        {
            try
            {
                var uri = GetUri(request);
                return await Client.GetAsync(uri);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> PostAsync(PostRequest req)
        {
            try
            {
                var uri = GetUri(req);
                var json = Json.Serialize(req.Data);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                return await Client.PostAsync(uri, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static HttpClient Client { get; } = new HttpClient();

        private static string GetUri(HttpRequest request)
        {
            if (request.Params != null)
            {
                request.Uri = UriParamInjector.InjectParamList(request.Uri, request.Params);
            }

            return request.Uri;
        }

        private HttpRequester() { }
    }
}
