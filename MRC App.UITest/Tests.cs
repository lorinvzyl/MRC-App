using System;
using System.IO;
using System.Linq;
using MRC_App.Views;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MRC_App.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        //In this scenario, to avoid having to start up the app for every possible task, screenshots will be taken to verify outputs

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

        [Test]
        public void RegisterUser()
        {
            //Register valid user account
        }

        [Test]
        public void LoginAndExplore()
        {
            //Login user and navigate to all possible pages
        }

        [Test]
        public void TestValidation()
        {
            //Validate error display for incorrect inputs
        }

        [Test]
        public void InteractHome()
        {
            //Interact with video, scroll and blog collection
        }

        [Test]
        public void InteractBlog()
        {
            //Interact with scroll and blog collection
        }

        [Test]
        public void InteractBlogDetailed()
        {
            //Interact with scroll, read more, and comments
        }

        [Test]
        public void InteractEvent()
        {
            //Interact with calendar navigation
        }

        [Test]
        public void InteractEventsDetailed()
        {
            //Interact with scroll, church location and RSVP
        }

        [Test]
        public void InteractDonate()
        {
            //Interact with special message, donation amount and donate button
        }

        [Test]
        public void InteractQR()
        {
            //possibly pass qr code into qr
        }

        [Test]
        public void InteractAccount()
        {
            //Interact with newsletter, reset password and delete account
        }

        [Test]
        public void InteractAccountEdit()
        {
            //Interact with editing fields and confirm changes taking place on accountpage and navflyout
        }

        [Test]
        public void InvalidEntryLogin()
        {
            //Check error handling for incorrect inputs
        }

        [Test]
        public void InvalidEntryRegister()
        {
            //Check error handling for incorrect inputs
        }

        [Test]
        public void InvalidEntryAccountEdit()
        {
            //Check error handling for incorrect inputs for email and birthday
        }

        [Test]
        public void InvalidEntryAccountResetPassword()
        {
            //Check error handling when incorrect password is given
        }

        [Test]
        public void InvalidEntryAccountDelete()
        {
            //Check error handling when incorrect password is given
        }

        [Test]
        public void InvalidEntryDonate()
        {
            //Check error handling when invalid donation amount is given
        }
    }
}
