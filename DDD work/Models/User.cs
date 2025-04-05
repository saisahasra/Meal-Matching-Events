using System.Collections.Generic;
using DDD_work.Models;

namespace DDD_work.Models
{
    public class User
    {

        public long UserID { get; set; } // unique user identifie
        public string Username { get; set; } // user's login username
        public string Password { get; set; } // user's login password
        public string FullName { get; set; } // user's full name for display
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } // user's age.
        public string Course { get; set; }  // User's uni course
        public string Hobbies { get; set; } // user's hobbies and interests
        public string AboutMe { get; set; } // brief description of user
        public string ProfilePicture { get; set; } // path to the users profile picture



    }
}
