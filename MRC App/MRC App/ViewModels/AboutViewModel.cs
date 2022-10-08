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

        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }


        public AboutViewModel()
        {
            IsVisible = false;
            Blog = new ObservableRangeCollection<Blog>();
            GetBlogs();
            GetVideo();
        }

        public AboutViewModel(bool isTest)
        {
            isVisible = false;
            Blog = new ObservableRangeCollection<Blog>();
        }

        public async Task GetBlogs()
        {
            var blogs = await RestService.GetBlogsCount(3);
            Blog.AddRange(blogs);
        }

        public async Task GetVideo()
        {
            var video = await RestService.GetLastVideo();

            var youtube = new YoutubeClient();

            if (video == null)
            {
                string vid = "IEKHzbwWSr4";
                var streamMani = await youtube.Videos.Streams.GetManifestAsync(vid);
                var streamIn = streamMani.GetMuxedStreams().GetWithHighestVideoQuality();
                
                if(streamIn != null)
                {
                    var stream = await youtube.Videos.Streams.GetAsync(streamIn);
                    var source = streamIn.Url;

                    Video = source;
                    return;
                }
            }

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.VideoURL);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            if(streamInfo != null)
            {
                var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                var source = streamInfo.Url;

                Video = source;
                IsVisible = true;
            }
        }

        public async Task Refresh()
        {
            IsBusy = true;

            Blog.Clear();
            Video = null;

            await GetVideo();
            await GetBlogs();

            IsBusy = false;
        }
    }
}