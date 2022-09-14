using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MRC_App.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static string Email { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string password { get; set; }
    }
}
