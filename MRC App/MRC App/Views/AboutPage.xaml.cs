﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MRC_App.ViewModels;
using MRC_App.Models;
using System.Linq;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Newtonsoft.Json;

namespace MRC_App.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void CollectionView_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is Blog blog))
                return;

            var json = JsonConvert.SerializeObject(blog);
            await Shell.Current.GoToAsync($"{nameof(BlogDetailed)}?Param={json}");
            ((CollectionView)sender).SelectedItem = null;
        }

        private void mediaSource_MediaOpened(object sender, EventArgs e)
        {
            ((MediaElement)sender).Speed = 0; //Xamarin community toolkit currently has a bug where autoplay being set to off doesn't work. This is a workaround.
        }
    }
}