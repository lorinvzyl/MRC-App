using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private ObservableCollection<Blog> Blog;
        public ObservableCollection<Blog> blog
        {
            get { return Blog; }
            set { Blog = value; }
        }

        public AboutViewModel()
        {
            blog = new ObservableCollection<Blog>();
            /*
             * Add video here
             * Add verse of the day here.
             */
            AddData();
        }

        private void AddData()
        {
            blog.Add(new Blog
            {
                ID = 0,
                BlogTitle = "How the Early Church Dealt with Racial and Cultural Division",
                Content = "It has never been more complicated to be a pastor than it is right now. At least that’s how it often seems. As racial tensions and culture clashes have dominated the headlines in our nation, too often those unwanted guests have decided to attend our churches as well. How do we navigate our ministries to the safe harbors of peace and unity while still fulfilling our prophetic call to proclaim the truth of the gospel that challenges our tendency to elevate our norms over others? And how can Scripture equip us to address today’s racial and ethnic tensions?",
                Img = "pexels6115945.jpg" 
            });
            blog.Add(new Blog
            {
                ID = 1,
                BlogTitle = "How Seminary Downsizing Cuts into Community",
                Content = "There is no good news coming from freestanding seminaries, and there hasn’t been for some time. Gordon-Conwell Theological Seminary closure of its campus in Hamilton, Massachusetts, is simply the latest in a string of downsizing among evangelical seminaries.",
                Img = "pexels208216.jpg" 
            });
            blog.Add(new Blog
            {
                ID = 2,
                BlogTitle = "Foster Children of Color Need Empathy, Sensitivity and Justice",
                Content = "I am a mother of seven, including four who were adopted after spending several years in a broken foster care system. I — like so many others who want to help, protect and minister to vulnerable children — began my journey with good intentions.",
                Img = "pexels7169640.jpg"
            });
        }
    }
}