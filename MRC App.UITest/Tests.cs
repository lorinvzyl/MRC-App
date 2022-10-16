using System;
using System.IO;
using System.Linq;
using System.Threading;
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
            app.Tap(c => c.Marked("LoginRegister"));
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

            app.EnterText("John2Doe");
            app.Back();

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

            app.EnterText("John2Doe");
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
            app.Screenshot("EventDateSelect");

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

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            //Interact with video, scroll
        }

        [Test]
        public void InteractBlog()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Blog"));
            app.WaitForElement(c => c.Marked("BlogLabel"));

            //Interact with scroll
            app.DragCoordinates(200, 722, 200, 200);
            app.Screenshot("BlogDrag");

            app.DragCoordinates(200, 200, 200, 722);
            app.DragCoordinates(200, 127, 200, 280);
            app.Screenshot("BlogRefresh");

            Thread.Sleep(5000); //waits for blogs to be refreshed, if it does not throw error then pass
            Assert.Pass();
        }

        [Test]
        public void InteractBlogDetailed()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Blog"));
            app.WaitForElement(c => c.Marked("BlogLabel"));
            app.TapCoordinates(200, 272);
            app.WaitForElement(c => c.Marked("BlogDetailedLabel"));

            //Interact with scroll, read more, and comments


        }

        [Test]
        public void InteractEvent()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Events"));
            app.WaitForElement(c => c.Marked("EventsLabel"));

            //Interact with calendar navigation
            var month = DateTime.Today.Month;
            var prevMonth = DateTime.Today.Month - 1;
            app.Tap(c => c.Marked("LeftIcon"));
            app.WaitForElement(c => c.Marked($"{prevMonth}"));
            app.Screenshot("Previous Month");

            app.Tap(c => c.Marked("RightIcon"));
            AppResult[] result = app.WaitForElement(c => c.Marked($"{month}"));

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void InteractEventsDetailed()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Events"));
            app.WaitForElement(c => c.Marked("EventsLabel"));

            //Interact with scroll, church location and RSVP
            app.TapCoordinates(312, 385);
            app.WaitForElement(c => c.Marked("EventsDetailedLabel"));
            app.Screenshot("EventsDetailed");

            app.Tap(c => c.Marked("Location"));
            //app.WaitForElement(c => c.Marked(""));

            app.Tap(c => c.Marked("EventRSVP"));
            //app.WaitForElement(c => c.Marked(""));

            AppResult[] result = app.WaitForElement(c => c.Marked("EventsLabel")); //placeholder, will be confirming pop ups

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void InteractDonate()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Donate"));
            AppResult[] result = app.WaitForElement(c => c.Marked("DonateLabel"));
            //Interact with special message, donation amount and donate button

            app.Tap(c => c.Marked("DonateComment"));
            app.EnterText("This is a special message");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("DonatePrice"));
            app.EnterText("10");
            app.DismissKeyboard();

            app.Screenshot("DonateEntries");

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void InteractQR()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("QR"));
            AppResult[] result = app.WaitForElement(c => c.Marked("QRLabel"));
            app.Screenshot("QR");

            //possibly pass qr code into qr

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void InteractAccount()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Screenshot("ValidEntryLogin");

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Account"));
            AppResult[] result = app.WaitForElement(c => c.Marked("AccountLabel"));

            //Interact with newsletter, reset password and delete account
            app.Tap(c => c.Marked("NewsletterSwitch"));

            app.Tap(c => c.Marked("AccountReset"));
            app.WaitForNoElement(c => c.Marked("AccountReset"));
            app.Screenshot("AccountResetPasswordPopUp");
            //dismiss pop up

            app.Tap(c => c.Marked("AccountDelete"));
            app.WaitForNoElement(c => c.Marked("AccountDelete"));
            app.Screenshot("AccountDeletePopUp");
            //dismiss pop up

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void InteractAccountEdit()
        {
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("LoginButton"));

            app.WaitForElement(c => c.Marked("HomeLabel"));

            app.Tap(c => c.Marked("FlyoutIcon"));
            app.WaitForElement(c => c.Marked("Avatar"));

            app.Tap(c => c.Marked("Account"));
            app.WaitForElement(c => c.Marked("AccountLabel"));
            //Interact with editing fields and confirm changes taking place on accountpage and navflyout

            app.Tap(c => c.Marked("AccountFNameEdit"));
            app.WaitForElement(c => c.Marked("ValueEntry"));

            app.Tap("ValueEntry");
            app.ClearText();
            app.EnterText("Joe");

            app.Tap(c => c.Marked("Back"));
            app.WaitForElement(c => c.Marked("Joe"));

            app.Tap(c => c.Marked("AccountLNameEdit"));
            app.WaitForElement(c => c.Marked("ValueEntry"));

            app.Tap(c => c.Marked("ValueEntry"));
            app.ClearText();
            app.EnterText("Dohn");

            app.Tap(c => c.Marked("Back"));
            app.WaitForElement("Dohn");

            app.Tap(c => c.Marked("FlyoutIcon"));
            AppResult[] result = app.WaitForElement(c => c.Marked("Joe Dohn"));

            Assert.IsTrue(result.Any());
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
            AppResult[] result = app .WaitForElement(c => c.Marked("Incorrect password/email"));
            app.Screenshot("ValidEntriesButIncorrect");

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void InvalidEntryRegister()
        {
            //Check error handling for incorrect inputs
            //Register
            app.WaitForElement(c => c.Marked("Log into your account"));
            app.Tap(c => c.Marked("LoginRegister"));
            app.WaitForElement(c => c.Marked("Register your account"));

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

            Assert.Pass();
        }

        [Test]
        public void InvalidEmailEntryAccountEdit()
        {
            //Check error handling for incorrect inputs for email and birthday
            app.WaitForElement(c => c.Marked("Log into your account"));

            app.Tap(c => c.Marked("LoginEmail"));
            app.EnterText("johndoe@gmail.com");
            app.PressEnter();

            app.EnterText("John2Doe");
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

            app.EnterText("John2Doe");
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

            app.EnterText("John2Doe");
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

            app.EnterText("John2Doe");
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

            app.EnterText("John2Doe");
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

            Assert.Pass();
        }
    }
}
