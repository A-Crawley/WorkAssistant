using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkAssistant.Core
{
    public static class RestClient
    {
        private static HttpClient CreateClient(string baseAddress)
        {
            return new HttpClient {BaseAddress = new Uri(baseAddress)};
        }
        
        public static Task<T> GetJsonAsync<T>(string baseAddress, string route)
        {
            var client = CreateClient(baseAddress);
            return client.GetFromJsonAsync<T>(route);
        }

        public static Task<HttpResponseMessage> PutJsonAsync(string baseAddress, string route, object payload)
        {
            var client = CreateClient(baseAddress);
            return client.PutAsJsonAsync(route, JsonConvert.SerializeObject(payload));
        }
    }
}