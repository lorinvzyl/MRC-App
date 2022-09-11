using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRC_App.Services
{
    public interface IRestService
    {
        Task DeleteUser(int id); //need to implement this
        //interacts with user table
        Task<bool> Login(string email, string password);
        //interacts with user table
        Task UpdateUser(User user); //need to implement this
        //interacts with user table
        Task<User> GetUser(int id); //need to implement this
        //interacts with user table
        Task<User> GetUserByEmail(string email);
        //interacts with user table
        Task Register(User user);
        //interacts with user table
        Task<List<Blog>> GetBlogs();
        //interacts with blog table
        Task<List<Event>> GetEvents();
        //interacts with event table
        Task Donate(Donation donations);
        //Interacts with donation table
        Task Attend(int UserId, DateTime date); //need to implement this
        //interacts with userevent table?
        Task<Video> GetLivestream(); //need to implement this
        //Interacts with video table
        Task<List<Comment>> GetBlogComments(int blogId); //need to implement this
        //Communicates with comment and the reply tables?
        Task AddBlogComment(Comment comment); //need to implement this
        //Adds a general comment, interacts with comments.
        Task AddBlogReply(Reply reply); //need to implement this
        //Adds a reply to a comment, sends commentId as parent. Interacts with reply table?
        Task<List<Location>> GetChurchLocations(); //need to implement this
        //Interacts with location table?
        Task UpdateNewsletter(int userId); //need to implement this
        //Communicates with user table
    }
}
