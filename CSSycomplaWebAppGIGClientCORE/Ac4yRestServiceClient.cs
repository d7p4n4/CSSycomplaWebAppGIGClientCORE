﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CSSycomplaWebAppGIGClientCORE
{
    public class Ac4yRestServiceClient
    {
        public string Server { get; set; }
        public string AuthorizationKey { get; set; }

        public Ac4yRestServiceClient() { }

        public Ac4yRestServiceClient(string server)
        {
            Server = server;
        }

        public Ac4yRestServiceClient(string server, string key)
        {
            Server = server;
            AuthorizationKey = key;
        }

        public string GET(string path, string request)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Server + path);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(Server + path),
                Content = new StringContent(request, UTF8Encoding.UTF8, "application/json"),
            };

            HttpContent content = new StringContent(request, UTF8Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.SendAsync(httpRequest).Result;
            string result = message.Content.ReadAsStringAsync().Result;

            return result;
        }

        public string GET(string pathAndParameter)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Server + "?" + pathAndParameter);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage message = httpClient.GetAsync(Server).Result;
            string result = message.Content.ReadAsStringAsync().Result;

            return result;
        }

        public string POST(string path, string request)
        {
            using (var httpClient = new HttpClient())
            {
                using (var httpRequest = new HttpRequestMessage(new HttpMethod("POST"), Server + path))
                {
                    httpRequest.Content = new StringContent(request);
                    httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    if (AuthorizationKey != null && !AuthorizationKey.Equals(""))
                        httpRequest.Headers.TryAddWithoutValidation("Authorization", "key=" + AuthorizationKey);

                    var response = httpClient.SendAsync(httpRequest).Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
