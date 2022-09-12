using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MRC_App.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool isNewsletter { get; set; }
        public string Password { get; set; }

    }
}
