using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MRC_App.Models;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using MRC_App.Services;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace MRC_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Blog> blog;
        private string video;

        public ObservableRangeCollection<Blog> Blog
        {
            get { return blog; }
            set { blog = value; }
        }

        public string Video 
        {
            get { return video; }
            set { video = value; }
        }


        public AboutViewModel()
        {
            blog = new ObservableRangeCollection<Blog>();
            video = new string("");
            
            GetBlogs();
            GetVideo();
        }

        private async Task GetBlogs()
        {
            var blogs = await RestService.GetBlogsCount(3);
            Blog.AddRange(blogs);
        }

        private async Task GetVideo()
        {
            var video = await RestService.GetLastVideo();

            var youtube = new YoutubeClient();

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.VideoURL);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            if(streamInfo != null)
            {
                var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                var source = streamInfo.Url;

                Video = source;
            }
        }

        public async Task Refresh()
        {
            IsBusy = true;

            Blog.Clear();
            Video = null;

            GetVideo();
            GetBlogs();

            IsBusy = false;
        }
    }
}