using IIS.Web.Services.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace IIS.Web.API.Helpers
{
    public static class GetDeserializedJsonData<T> where T : class
    {
        private static HttpClient client;

        public static async Task<T> DeserializedJsonData(string url)
        {
            client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsonResponseAsString = await response.Content.ReadAsStringAsync();

            T deserializedJsonObject = JsonConvert.DeserializeObject<T>(jsonResponseAsString);

            return deserializedJsonObject;

        }

    }
}