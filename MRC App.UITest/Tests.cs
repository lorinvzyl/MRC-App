using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MRC_App.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void LoginIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Log into your account"));
            app.Screenshot("Login screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void RegisterIsDisplayed()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));
            app.Tap(c => c.Text("No account? Sign up here"));
            AppResult[] results = app.WaitForElement(c => c.Marked("Register your account"));

            app.Screenshot("Register screen.");

            Assert.IsTrue(results.Any());
        }
    }
}
