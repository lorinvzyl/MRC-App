﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace MRC_App.UnitTests
{
    [TestClass]
    public class Unit_Tests
    {
        //Collections
        [TestMethod]
        public void AddBlogAbout()
        {
            //Arrange
            AboutViewModel avm = new AboutViewModel(); //passing in true in order to not call default constructor, which calls the database.
            var blog = new List<Models.Blog>();
            blog.Add(new Models.Blog
            {
                Author = "Pastor",
                BlogTitle = "BlogTitle",
                Content = "Very large content",
                Description = "Short description",
                ImagePath = "websitelink",
                Id = 1
            });

            IEnumerable<MRC_App.Models.Blog> blogs = blog;

            //Act
            avm.Blog.AddRange(blogs);

            //Assert
            Assert.IsTrue(avm.Blog.Count == 1);
        }

        [TestMethod]
        public void AddBlogTest()
        {
            //Arrange
            BlogViewModel bvm = new BlogViewModel(true); //passing in true in order to not call default constructor, which calls the database.
            var blog = new List<Models.Blog>();

            blog.Add(new Models.Blog
            {
                Author = "Pastor",
                BlogTitle = "BlogTitle",
                Content = "Very large content",
                Description = "Short description",
                ImagePath = "websitelink",
                Id = 1
            });

            IEnumerable<MRC_App.Models.Blog> blogs = blog;

            //Act
            bvm.Blogs.AddRange(blogs);

            //Assert
            Assert.IsTrue(bvm.Blogs.Count == 1);
        }

        [TestMethod]
        public async Task AddVideoTest()
        {
            //Arrange
            AboutViewModel avm = new AboutViewModel();

            Models.Video vid = new Models.Video
            {
                VideoURL = "Xu5rKjAqY6U",
                Id = 1
            };

            
            var youtube = new YoutubeClient();
            var streamMani = await youtube.Videos.Streams.GetManifestAsync(vid.VideoURL);
            var streamIn = streamMani.GetMuxedStreams().GetWithHighestVideoQuality();

            if(streamIn != null)
            {
                var source = streamIn.Url;
                vid.VideoURL = source;
            }

            //Act
            avm.Video = vid.VideoURL;

            //Assert
            Assert.IsNotNull(avm.Video);
        }

        [TestMethod]
        public void AddEvents()
        {
            //Arrange
            EventsViewModel evm = new EventsViewModel(true);
            List<Models.Event> events = new List<Models.Event>();
            IEnumerable<Models.Event> _event;

            events.Add(new Models.Event()
            {
                EventDate = DateTime.Now,
                EventDescription = "EventDesc",
                EventName = "EventName",
                Id = 1,
                RSVPCloseDate = DateTime.Now.AddDays(5),
                SpacesAvailable = 10,
                SpacesTaken = 1,
                Venue = "Location"
            });

            _event = events;

            //Act
            foreach(var item in _event)
            {
                evm.Event.Add(item.EventDate, new List<Models.Event>(evm.GenerateEvent(item)));
            }

            //Assert
            Assert.IsNotNull(evm.Event);
        }

        [TestMethod]
        public void AddSelectedEvent()
        {
            //Arrange
            EventsDetailedViewModel edvm = new EventsDetailedViewModel();

            Models.Event _event = new Models.Event()
            {
                EventDate = DateTime.Now,
                EventDescription = "EventDesc",
                EventName = "EventName",
                Id = 1,
                RSVPCloseDate = DateTime.Now.AddDays(5),
                SpacesAvailable = 10,
                SpacesTaken = 1,
                Venue = "Location"
            };

            //Act
            edvm.SelectedEvent = _event;

            //Assert
            Assert.IsTrue(edvm.SelectedEvent != null);
        }

        [TestMethod]
        public void AddComments()
        {
            //Arrange
            BlogDetailedViewModel bdvm = new BlogDetailedViewModel();
            IEnumerable<Models.Comment> comments;
            List<Models.Comment> comment = new List<Models.Comment>();
            List<Models.Reply> reply = new List<Models.Reply>();

            reply.Add(new Models.Reply()
            {
                CommentText = "CommentText2",
                CommentId = 1,
                Id = 2,
                UserName = "Ree"
            });

            comment.Add(new Models.Comment()
            {
                CommentText = "CommentText",
                Id = 1,
                BlogId = 1,
                Reply = reply,
                UserName = "Ree1"
            });

            comments = comment;

            //Act
            bdvm.Comments.AddRange(comments);

            //Assert
            Assert.IsTrue(bdvm.Comments.Count == 1);
        }

        [TestMethod]
        public void AddSelectedComments()
        {
            //Arrange
            BlogDetailedViewModel bdvm = new BlogDetailedViewModel();
            List<Models.Reply> reply = new List<Models.Reply>();

            reply.Add(new Models.Reply()
            {
                CommentText = "CommentText2",
                CommentId = 1,
                Id = 2,
                UserName = "Ree"
            });

            ICollection<Models.Reply> replies = reply;

            Models.Comment comment = new Models.Comment()
            {
                CommentText = "CommentText",
                Id = 1,
                BlogId = 1,
                Reply = replies,
                UserName = "Ree1"
            };

            //Act
            bdvm.SelectedComment = comment;

            //Assert
            Assert.IsTrue(bdvm.SelectedComment != null);
        }

        [TestMethod]
        public void AddLocations()
        {
            //Arrange
            LocationViewModel lvm = new LocationViewModel(true);
            IEnumerable<Models.Location> locations;
            List<Models.Location> location = new List<Models.Location>();

            location.Add(new Models.Location()
            {
                MapsURL = "string",
                Id = 1,
                Name = "LocationName",
                Pastor = "PastorName"
            });

            locations = location;

            //Act
            lvm.Locations.AddRange(locations);

            //Assert
            Assert.IsTrue(lvm.Locations.Count == 1);
        }
    }
}
