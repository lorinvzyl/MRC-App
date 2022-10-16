using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MRC_App.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.mrc_app").PreferIdeSettings().EnableLocalScreenshots().StartApp();
            }
            else
            {
                return ConfigureApp.iOS.StartApp();
            }
        }
    }
}