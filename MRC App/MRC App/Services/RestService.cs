﻿using MRC_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MRC_App.Services
{
    public class RestService
    {
        static HttpClient client;
        //static string BaseUrl = "http://10.0.2.2:32223/";
        static string BaseUrl = "https://reformedchurchmidrandapi.azurewebsites.net";

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
            var json = await client.GetAsync("api/Blogs");

            if (!json.IsSuccessStatusCode)
                return null;

            string urlContent = await json.Content.ReadAsStringAsync();
            var blogs = JsonConvert.DeserializeObject<IEnumerable<Blog>>(urlContent);
            return blogs;
        }

        public static async Task<User> GetUserByEmail(string email)
        {
            var json = await client.GetAsync($"api/Users/email={email}");
            if (!json.IsSuccessStatusCode)
                return null;

            string urlContent = await json.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(urlContent);
            return user;
        }

        public static async Task<User> GetUser(int id)
        {
            var json = await client.GetAsync($"api/Users/{id}");
            if (!json.IsSuccessStatusCode)
                return null;

            string urlContent = await json.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(urlContent);
            return user;
        }

        public static async Task<IEnumerable<Event>> GetEvents()
        {
            var json = await client.GetAsync("api/Events");
            if (!json.IsSuccessStatusCode)
                return null;

            string urlContent = await json.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<IEnumerable<Event>>(urlContent);
            return events;
        }

        public static async Task<bool> UpdateEvent(int id, Event _event)
        {
            var json = JsonConvert.SerializeObject(_event);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/Events/{id}", content);

            if (!response.IsSuccessStatusCode)
                return false;
            return true;
        }

        public static async Task<UserEvent> GetUserEvent(int id, int userId)
        {
            var response = await client.GetAsync($"api/UserEvents/{id}/{userId}");
            if (!response.IsSuccessStatusCode)
                return null;

            var urlContent = await response.Content.ReadAsStringAsync();
            var userEvent = JsonConvert.DeserializeObject<UserEvent>(urlContent);

            return userEvent;
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

        public static async Task<bool> UpdateUser(int id, User user)
        {
            bool updated = false;

            if (user == null || id != user.Id)
                return updated;

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/Users/{id}", content);

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
            var json = await client.GetAsync($"api/Comments/blogId={blogId}");
            if (!json.IsSuccessStatusCode)
                return null;

            string urlContent = await json.Content.ReadAsStringAsync();
            var blogComments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(urlContent);

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

        public static async Task<bool> AddBlogReply(Reply comment)
        {
            var replied = false;

            if (comment == null)
                return replied;

            var json = JsonConvert.SerializeObject(comment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Replies", content);

            if(!response.IsSuccessStatusCode)
                return replied;

            replied = true;
            return replied;
        }

        public static async Task<IEnumerable<Location>> GetChurchLocations()
        {
            var json = await client.GetAsync("api/Locations");
            if (!json.IsSuccessStatusCode)
                return null;

            string urlContent = await json.Content.ReadAsStringAsync();
            var locations = JsonConvert.DeserializeObject<IEnumerable<Location>>(urlContent);

            return locations;
        }

        public static async Task<IEnumerable<Blog>> GetBlogsCount(int count)
        {
            var json = await client.GetAsync($"api/Blogs/count={count}");
            if (!json.IsSuccessStatusCode)
                return null;

            string urlContent = await json.Content.ReadAsStringAsync();
            var blogs = JsonConvert.DeserializeObject<IEnumerable<Blog>>(urlContent);

            return blogs;
        }

        public static async Task<Video> GetLastVideo()
        {
            var json = await client.GetAsync("api/Videos/last");
            if (!json.IsSuccessStatusCode)
                return null;

            string urlContent = await json.Content.ReadAsStringAsync();
            var video = JsonConvert.DeserializeObject<Video>(urlContent);

            if (video == null)
                return null;

            return video;
        }
    }
}
