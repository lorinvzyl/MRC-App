using MRC_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MRC_App.Services
{
    public class RestService
    {
        static HttpClient client;
        JsonSerializer serializerOptions;
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

        public static async Task<IEnumerable<Blog>> GetBlogs()
        {
            var json = await client.GetStringAsync("api/Blogs");
            var blogs = JsonConvert.DeserializeObject<IEnumerable<Blog>>(json);
            return blogs;
        }

        public static async Task<User> GetUserByEmail(string email)
        {
            var json = await client.GetStringAsync($"api/Users/email={email}");
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }

        public static async Task<IEnumerable<Event>> GetEvents()
        {
            var json = await client.GetStringAsync("api/Events");
            var events = JsonConvert.DeserializeObject<IEnumerable<Event>>(json);
            return events;
        }

        public static async Task<bool> Donate(Donation donation)
        {
            bool donated = false;
            var json = JsonConvert.SerializeObject(donation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Donations", content);

            if (!response.IsSuccessStatusCode)
                return donated;

            donated = true;
            return donated;
        }
    }
}
