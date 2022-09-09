using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRC_App.Services
{
    public interface IRestService
    {
        Task DeleteUser(int id);
        Task Login(string email, string password);
        Task UpdateUser(User user);
        Task<List<User>> GetUser(int id);
        Task<List<User>> GetUserByEmail(string email);
        Task Register(User user);
        Task<List<Blog>> GetBlogs();
        Task<List<Blog>> GetEvents();
        Task Donate(int id, int amount, string message);
        Task Attend(int UserId, DateTime date);
        Task<List<Video>> GetLivestream(bool isLive);
        Task<List<Comments>> GetBlogComments(int blogId);
        //Task<List<Replies>> GetBlogReplies(int blogId);
        Task PutBlogComment(int blogId, int userId, string comment);
        Task PutBlogReply(int blogId, int userId, int commentId , string reply);
        Task<List<Locations>> GetChurchLocations();
        Task UpdateNewsletter(int userId);
    }
}
