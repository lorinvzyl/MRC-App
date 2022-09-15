using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MRC_App.ViewModels
{
    public class BlogDetailedViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Comment> comments;
        public ObservableRangeCollection<Comment> Comments
        {
            get { return comments; }
            set 
            { 
                comments = value;
                OnPropertyChanged();
            }
        }
        public BlogDetailedViewModel()
        {
            Comments = new ObservableRangeCollection<Comment>();
        }

        private async Task AddData()
        {

        }
    }
}
