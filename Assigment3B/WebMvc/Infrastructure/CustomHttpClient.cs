﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        public CustomHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetStringAsync(string uri, 
            string authorizationToken = null, 
            string authorizationMethod = "Bearer")
        {
            //http://localhost:7810/api/EventItems/Items?pageIndex=0&pageSize=5
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await _client.SendAsync(requestMessage);
            Debug.WriteLine("***REQUEST MESSAGE" + requestMessage);
            return await response.Content.ReadAsStringAsync();

        }
    }
}
