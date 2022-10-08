using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace MRC_App.Tests
{
    [TestClass]
    public class Unit_Tests
    {
        [TestMethod()]
        public void AddBlogTest()
        {
            //Arrange
            AboutViewModel avm = new AboutViewModel(true); //passing in true in order to not call default constructor, which calls the database.
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
        public async Task AddVideoTest()
        {
            //Arrange
            AboutViewModel avm = new AboutViewModel(true);

            Models.Video vid = new Models.Video
            {
                VideoURL = "Xu5rKjAqY6U",
                Id = 1
            };

            //Act
            var youtube = new YoutubeClient();
            var streamMani = await youtube.Videos.Streams.GetManifestAsync(vid.VideoURL);
            var streamIn = streamMani.GetMuxedStreams().GetWithHighestVideoQuality();

            if(streamIn != null)
            {
                var source = streamIn.Url;
                vid.VideoURL = source;
            }

            avm.Video = vid.VideoURL;

            //Assert
            Assert.IsNotNull(avm.Video);
        }
    }
}
