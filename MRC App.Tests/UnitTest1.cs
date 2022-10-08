using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRC_App.ViewModels;
using System;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MRC_App.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddBlogTest()
        {
            //Arrange
            var avm = new AboutViewModel();
            var blog = new ObservableRangeCollection<MRC_App.Models.Blog>();

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

            avm.Blog = blog;

            //Assert
            Assert.IsNotNull(avm.Blog);
        }
    }
}
