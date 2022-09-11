using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MRC_App.Models;

namespace MRC_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private ObservableCollection<Blog> Blog;
        private ObservableCollection<Video> Video;

        public ObservableCollection<Blog> blog
        {
            get { return Blog; }
            set { Blog = value; }
        }

        public ObservableCollection<Video> video
        {
            get { return Video; }
            set { Video = value; }
        }


        public AboutViewModel()
        {
            blog = new ObservableCollection<Blog>();
            video = new ObservableCollection<Video>();

            /*
             * Add video here
              
             * Add verse of the day here.
             */
            AddData();
            AddVid();

        }

        private void AddData()
        {
            blog.Add(new Blog
            {
                ID = 0,
                BlogTitle = "How the Early Church Dealt with Racial and Cultural Division",
                Content = "It has never been more complicated to be a pastor than it is right now. At least that’s how it often seems. As racial tensions and culture clashes have dominated the headlines in our nation, too often those unwanted guests have decided to attend our churches as well. How do we navigate our ministries to the safe harbours of peace and unity while still fulfilling our prophetic call to proclaim the truth of the gospel that challenges our tendency to elevate our norms over others? And how can Scripture equip us to address today's racial and ethic tensions?                                                                                                                                                                                           In the Acts of the Apostles, Luke hightlights one of the greatest threats the early church faced: ethnocentrism and cultural pride within the fellowship of believers. As the gospel spread beyond the initial band of Jesus' Jewish followers across geographic and cultural boundaries, these impulses threatned to pull the adolescent church apart. Eventually the controversy lead to the Jerusalem Council described in Acts 15.   ",
                Img = "pexels6115945.jpg",

            });
            blog.Add(new Blog
            {
                ID = 1,
                BlogTitle = "How Seminary Downsizing Cuts into Community",
                Content = "There is no good news coming from freestanding seminaries, and there hasn’t been for some time. Gordon-Conwell Theological Seminary closure of its campus in Hamilton, Massachusetts, is simply the latest in a string of downsizing among evangelical seminaries. There is always a temptation to market this future as a “pivot”—a courageous choice toward a brighter future. But talking about the sale of a residential campus in this way neglects the truth of what is lost. I’d like to tell you a little about what may soon be lost, with the hope that we might imagine another way forward for theological education.                                                                                                                                     Theological education is not like other forms of education.In evangelical spaces especially  it seeks to train those who are discerning a call to ministry.A “call to ministry” is a notoriously vague sense that may grow in intensity, but that may also get lost in the busyness of life. To heed this call, you must listen for it. You also must receive it from others. ",
                Img = "pexels208216.jpg",

            });
            blog.Add(new Blog
            {
                ID = 2,
                BlogTitle = "Foster Children of Color Need Empathy, Sensitivity and Justice",
                Content = "I am a mother of seven, including four who were adopted after spending several years in a broken foster care system. I — like so many others who want to help, protect and minister to vulnerable children — began my journey with good intentions. I frequently meet with pastors and churches who have servant hearts and adoption or foster care ministries. But within that eagerness to do charitable work is a disconnect I see time and time again: Predominantly white churches from the suburbs filled with well-meaning people who cannot understand the life experiences of the primarily minority communities they are serving.                                                                                                                            This disconnect causes them to question the family’s parenting style, discipline techniques, choices, decisions and way of life. Some even wanted to permanently parent these children themselves. This is not the answer. I am asking all who seek to minister to vulnerable children: Stop for a moment and listen. Listen, because it is morally critical that you learn.",
                Img = "pexels7169640.jpg",

            });


        }

        private void AddVid()
        {
            video.Add(new Video
            {
                Id = 0,
                VideoURL = "https://youtu.be/7mAgyNkPfCw"

            });

        }
    }
}