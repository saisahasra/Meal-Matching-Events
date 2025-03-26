using System.Text.Json.Serialization;

namespace ConnectifyApp.Models
{
    public class User
    {
        [JsonPropertyName("UserID")]
        public int UserID { get; set; }

        [JsonPropertyName("Username")]
        public string Username { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("Age")]
        public int Age { get; set; }

        [JsonPropertyName("Course")]
        public string Course { get; set; }

        [JsonPropertyName("Hobbies")]
        public string Hobbies { get; set; }

        [JsonPropertyName("AboutMe")]
        public string AboutMe { get; set; }

        [JsonPropertyName("ProfilePicture")]
        public string ProfilePicture { get; set; }
    }
}