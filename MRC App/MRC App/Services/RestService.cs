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

            if (donation == null)
                return donated;

            var json = JsonConvert.SerializeObject(donation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Donations", content);

            if (!response.IsSuccessStatusCode)
                return donated;

            donated = true;
            return donated;
        }

        public static async Task<bool> DeleteUser(string email)
        {
            bool deleted = false;

            if (email == null)
                return deleted;

            var response = await client.DeleteAsync($"api/Users/email={email}");

            if (!response.IsSuccessStatusCode)
                return deleted;

            deleted = true;

            return deleted;
        }

        public static async Task<bool> UpdateUser(string email, User user)
        {
            bool updated = false;

            if (user == null || email == null)
                return updated;

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/Users/email={email}", content);

            if (!response.IsSuccessStatusCode)
                return updated;

            updated = true;

            return updated;
        }

        public static async Task<bool> Attend(UserEvent userEvent)
        {
            bool attend = false;

            if (userEvent == null)
                return attend;

            var json = JsonConvert.SerializeObject(userEvent);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("api/UserEvents/Attend", content);

            if (!response.IsSuccessStatusCode)
                return attend;

            attend = true;

            return attend;
        }

        public static async Task<IEnumerable<Comment>> GetBlogComments(int blogId)
        {
            var json = await client.GetStringAsync($"api/Comments/blogId={blogId}");
            var blogComments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(json);

            return blogComments;
        }

        public static async Task<bool> AddBlogComment(Comment comment)
        {
            var commented = false;

            if (comment == null)
                return commented;

            var json = JsonConvert.SerializeObject(comment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Comments", content);

            if (!response.IsSuccessStatusCode)
                return commented;

            commented = true;

            return commented;
        }

        public static async Task<IEnumerable<Location>> GetChurchLocations()
        {
            var json = await client.GetStringAsync("api/Locations");
            var locations = JsonConvert.DeserializeObject<IEnumerable<Location>>(json);

            return locations;
        }
    }
}
