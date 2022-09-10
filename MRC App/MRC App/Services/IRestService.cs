﻿using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRC_App.Services
{
    public interface IRestService
    {
        Task DeleteUser(int id);
        //interacts with user table
        Task Login(string email, string password); //Will need to return a bool likely
        //interacts with user table
        Task UpdateUser(User user);
        //interacts with user table
        Task<User> GetUser(int id);
        //interacts with user table
        Task<User> GetUserByEmail(string email);
        //interacts with user table
        Task Register(User user);
        //interacts with user table
        Task<List<Blog>> GetBlogs();
        //interacts with blog table
        Task<List<Events>> GetEvents();
        //interacts with event table
        Task Donate(Donations donations);
        //Interacts with donation table
        Task Attend(int UserId, DateTime date);
        //interacts with userevent table?
        Task<Video> GetLivestream(bool isLive);
        //Interacts with video table
        Task<List<Comments>> GetBlogComments(int blogId);
        //Communicates with comment and the reply tables?
        //Task<List<Replies>> GetBlogReplies(int blogId);
        Task PutBlogComment(int blogId, int userId, string comment);
        //Adds a general comment, interacts with comments.
        Task PutBlogReply(int blogId, int userId, int commentId , string reply);
        //Adds a reply to a comment, sends commentId as parent. Interacts with reply table?
        Task<List<Locations>> GetChurchLocations();
        //Interacts with location table?
        Task UpdateNewsletter(int userId);
        //Communicates with user table
    }
}
