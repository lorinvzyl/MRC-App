using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MRC_App.Services
{
    public class RestService
    {
        static HttpClient client;
        JsonSerializerOptions serializerOptions;
        static string BaseUrl;

        static RestService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }
    }
}
