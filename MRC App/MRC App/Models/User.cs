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
        public string Email { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] HashedPassword { get; set; }

    }
}
