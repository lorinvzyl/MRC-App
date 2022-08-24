using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MRC_App.Models;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    internal class BlogViewModel : BaseViewModel
    {
        public ObservableCollection<Blog> blog { get; set; }
        
        public BlogViewModel()
        {
            Title = "Blog";
            blog = new ObservableCollection<Blog>();
           
            AddData();

        }

        private void AddData()
        {
            blog.Add(new Blog
            {
                ID = 0,
                Title = "How the Early Church Dealt with Racial and Cultural Division",
                Content = "It has never been more complicated to be a pastor than it is right now. At least that’s how it often seems. As racial tensions and culture clashes have dominated the headlines in our nation, too often those unwanted guests have decided to attend our churches as well. How do we navigate our ministries to the safe harbors of peace and unity while still fulfilling our prophetic call to proclaim the truth of the gospel that challenges our tendency to elevate our norms over others? And how can Scripture equip us to address today’s racial and ethnic tensions? " +
                "In the Acts of the Apostles, Luke highlights one of the greatest threats the early church faced:         ethnocentrism and cultural pride within the fellowship of believers. As the gospel spread beyond the initial band of Jesus' Jewish followers across geographic and cultural boundaries, these impulses threatened to pull the adolescent chuch part.",
                Img = "https://images.pexels.com/photos/6115945/pexels-photo-6115945.jpeg"
            });
            blog.Add(new Blog
            {
                ID = 1,
                Title = "How Seminary Downsizing Cuts into Community",
                Content = "There is no good news coming from freestanding seminaries, and there hasn’t been for some time. Gordon-Conwell Theological Seminary closure of its campus in Hamilton, Massachusetts, is simply the latest in a string of downsizing among evangelical seminaries.",
                Img = "https://images.pexels.com/photos/208216/pexels-photo-208216.jpeg"
            });
            blog.Add(new Blog
            {
                ID = 2,
                Title = "Foster Children of Color Need Empathy, Sensitivity and Justice",
                Content = "I am a mother of seven, including four who were adopted after spending several years in a broken foster care system. I — like so many others who want to help, protect and minister to vulnerable children — began my journey with good intentions.",
                Img = "https://images.pexels.com/photos/7169640/pexels-photo-7169640.jpeg"
            });
            
        }
        
       

    }
}
 