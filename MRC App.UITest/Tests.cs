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
        public void RegisterUser()
        {
            //Register valid user account
            app.WaitForElement(c => c.Marked("Log into your account"));
            app.Tap(c => c.Text("No account? sign up here"));
            app.WaitForElement(c => c.Marked("Register your account"));

            app.Screenshot("Register Screen"); //ensures the register screen is being displayed

            //Enter account details
            app.Tap(c => c.Marked("RegisterFName"));
            app.EnterText("John");
            app.PressEnter();

            app.EnterText("Doe");
            app.PressEnter();

            app.EnterText("1990/11/21");
            app.PressEnter();

            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            //Ensure all fields have values
            app.Screenshot("ValidEntryRegister");

            app.Tap(c => c.Marked("RegisterButton"));

            //Valid entry and registration should navigate to login page
            AppResult[] result = app.WaitForElement(c => c.Marked("Log into your account"));
            app.Screenshot("Navigate to login from register");

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void LoginAndExplore()
        {
            //In order to not fluctuate database with entries, use register before this one.
            //Login user and navigate to all possible pages
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));
            app.Screenshot("Home");

            app.TapCoordinates(128, 272); //Select one of the blogs
            app.WaitForElement(c => c.Marked("BlogDetailedLabel"));
            app.Screenshot("BlogDetailedAbout");

            app.Tap(c => c.Marked("Back"));
            app.WaitForElement("HomeLabel");
            app.Screenshot("BlogDetailedAboutReturn");

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            app.Screenshot("FlyoutHome");

            app.Tap(c => c.Marked("Blog"));
            app.WaitForElement(c => c.Marked("BlogLabel"));
            app.Screenshot("Blog");

            app.TapCoordinates(200,272); //Select one of the blogs
            app.WaitForElement(c => c.Marked("BlogDetailedLabel"));
            app.Screenshot("BlogDetailedBlog");

            app.Tap(c => c.Marked("Back"));
            app.WaitForElement("BlogLabel");
            app.Screenshot("BlogDetailedBlogReturn");

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            app.Screenshot("FlyoutBlog");

            app.Tap(c => c.Marked("Donate"));
            app.WaitForElement(c => c.Marked("DonateLabel"));
            app.Screenshot("Donate");

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            app.Screenshot("FlyoutDonate");

            app.Tap(c => c.Marked("Events"));
            app.WaitForElement(c => c.Marked("EventsLabel"));
            app.Screenshot("Event");

            app.TapCoordinates(312, 385);

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            app.Screenshot("FlyoutEvent");

            app.Tap(c => c.Marked("QR"));
            app.WaitForElement(c => c.Marked("QRLabel"));
            app.Screenshot("QR");

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            app.Screenshot("FlyoutQR");

            app.Tap(c => c.Marked("Locations"));
            app.WaitForElement(c => c.Marked("LocationsLabel"));
            app.Screenshot("Locations");

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            app.Screenshot("FlyoutLocations");

            app.Tap(c => c.Marked("Account"));
            app.WaitForElement(c => c.Marked("AccountLabel"));
            app.Screenshot("Account");

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            app.Screenshot("FlyoutAccount");

            app.Tap(c => c.Marked("Logout"));
            AppResult[] result = app.WaitForElement(c => c.Marked("Log into your account"));
            app.Screenshot("Logout");

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void InteractHome()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with video, scroll and blog collection
        }

        [Test]
        public void InteractBlog()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with scroll and blog collection
        }

        [Test]
        public void InteractBlogDetailed()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with scroll, read more, and comments
        }

        [Test]
        public void InteractEvent()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with calendar navigation
        }

        [Test]
        public void InteractEventsDetailed()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with scroll, church location and RSVP
        }

        [Test]
        public void InteractDonate()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with special message, donation amount and donate button
        }

        [Test]
        public void InteractQR()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));


            //possibly pass qr code into qr
        }

        [Test]
        public void InteractAccount()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with newsletter, reset password and delete account
        }

        [Test]
        public void InteractAccountEdit()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with editing fields and confirm changes taking place on accountpage and navflyout
        }

        [Test]
        public void InvalidEntryLogin()
        {
            //Check error handling for incorrect inputs
            app.WaitForElement(c => c.Marked("Log into your account"));

            //Invalid entry, does not meet regex
            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("invalidemail");
            app.PressEnter();

            app.EnterText("invalidpassword");
            app.DismissKeyboard();
            app.Screenshot("InvalidEntryLogin");

            //Valid entry, but no user
            app.Tap(c => c.Marked("LoginEmail"));
            app.ClearText();
            app.EnterText("incorrect@email.com");
            app.PressEnter();

            app.ClearText();
            app.EnterText("ValidIncorrect8");

            app.DismissKeyboard();
            app.Tap(c => c.Marked("LoginButton"));
            app.WaitForElement(c => c.Marked("Incorrect password/email"));
            app.Screenshot("ValidEntriesButIncorrect");
        }

        [Test]
        public void InvalidEntryRegister()
        {
            //Check error handling for incorrect inputs
            //Register
            app.WaitForElement(c => c.Marked("Log into your account"));
            app.Tap(c => c.Marked("No account? Sign up here"));

            app.Tap(c => c.Marked("RegisterFName"));
            app.EnterText("John");
            app.PressEnter();

            app.EnterText("Doe");
            app.PressEnter();

            app.EnterText("10/11/2021"); //invalid date
            app.PressEnter();

            app.EnterText("johndoegmail.com"); //invalid email
            app.PressEnter();

            app.EnterText("Johnoe"); //invalid password
            app.DismissKeyboard();

            app.Screenshot("InvalidEntryRegister");
        }

        [Test]
        public void InvalidEmailEntryAccountEdit()
        {
            //Check error handling for incorrect inputs for email and birthday
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("LoginButton"));
            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Avatar"));
            app.WaitForElement(c => c.Marked("AccountLabel"));
            app.Tap(c => c.Marked("AccountEmailEdit"));

            app.WaitForElement(c => c.Marked("ValueEntry"));
            app.Tap("ValueEntry");
            app.EnterText("invalidemail");
            app.Tap(c => c.Marked("Back"));

            AppResult[] result = app.WaitForElement("AccountLabel");
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void InvalidBirthEntryAccountEdit()
        {
            //Check error handling for incorrect inputs for email and birthday
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("LoginButton"));
            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Avatar"));
            app.WaitForElement(c => c.Marked("AccountLabel"));
            app.Tap(c => c.Marked("AccountBirthEdit"));

            app.WaitForElement(c => c.Marked("ValueEntry"));
            app.Tap("ValueEntry");
            app.EnterText("03/01/2000");
            app.Tap(c => c.Marked("Back"));

            AppResult[] result = app.WaitForElement("AccountLabel");
            Assert.IsTrue(result.Any());
        }


        [Test]
        public void InvalidEntryAccountResetPassword()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("LoginButton"));
            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            //Check error handling when incorrect password is given
        }

        [Test]
        public void InvalidEntryAccountDelete()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("LoginButton"));
            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));
            //Check error handling when incorrect password is given
        }

        [Test]
        public void InvalidEntryDonate()
        {
            //Check error handling when invalid donation amount is given
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John@Doe");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("LoginButton"));
            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            //Donate page
            app.Tap(c => c.Marked("Donate"));
            app.WaitForElement(c => c.Marked("DonateLabel"));

            app.Tap(c => c.Marked("DonatePrice"));
            app.EnterText("ree"); //not a number
            app.DismissKeyboard();
            app.Screenshot("DonateInvalidEntry");

            app.Tap(c => c.Marked("DonatePrice"));
            app.EnterText("-1"); //negative number
            app.DismissKeyboard();
            app.Screenshot("DonateInvalidEntryTwo");
        }
    }
}
