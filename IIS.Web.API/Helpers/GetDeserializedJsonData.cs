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
    public class GetDeserializedJsonData<T> where T : class
    {
        private HttpClient _client;
        private string urlAdress;

        public GetDeserializedJsonData(HttpClient client, string url)
        {
            _client = client;
            urlAdress = url;
        }

        public async Task<T> DeserializedJsonData()
        {
            HttpResponseMessage response = await _client.GetAsync(urlAdress);
            response.EnsureSuccessStatusCode();
            string jsonResponseAsString = await response.Content.ReadAsStringAsync();

            T deserializedJsonObject = JsonConvert.DeserializeObject<T>(jsonResponseAsString);

            return deserializedJsonObject;

        }

    }
}