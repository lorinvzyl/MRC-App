using MRC_App.Models;
using Newtonsoft.Json;
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
        static string BaseUrl = "http://10.0.2.2:32223/";

        static RestService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public static async Task<bool> RegisterUser(User user)
        {
            bool registered = false;
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Users", content);

            if(!response.IsSuccessStatusCode)
            {
                return registered;
            }
            registered = true;
            return registered;
        }

        public static async Task<bool> LoginUser(User user)
        {
            bool login = false;
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Users/login", content);

            if(!response.IsSuccessStatusCode)
            {
                return login;
            }
            login = true;
            return login;
        }
    }
}
