using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MRC_App.Tests
{
    [TestClass]
    public class Unit_Tests
    {
        [TestMethod]
        public void AddBlogTest()
        {
            //Arrange
            AboutViewModel avm = new AboutViewModel(true); //passing in true in order to not call default constructor, which calls the database.
            var blog = new List<MRC_App.Models.Blog>();

            //Act
            blog.Add(new MRC_App.Models.Blog
            {
                Author = "Pastor",
                BlogTitle = "BlogTitle",
                Content = "Very large content",
                Description = "Short description",
                ImagePath = "websitelink",
                Id = 1
            });

            IEnumerable<MRC_App.Models.Blog> blogs = blog;

            avm.Blog.AddRange(blogs);

            //Assert
            Assert.IsTrue(avm.Blog.Count == 1);
        }
    }
}
