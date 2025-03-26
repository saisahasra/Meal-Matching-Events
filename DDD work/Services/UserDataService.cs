using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using DDD_work.Models;
using Microsoft.AspNetCore.Hosting;

namespace DDD_work.Services
{
    public class UserDataService
    {
        private readonly IWebHostEnvironment _env; // info about the web environment
        private readonly string _filePath = "users.json"; // path to the user data file

        public UserDataService(IWebHostEnvironment env) // Constructor to inject IWebHostEnvironment
        
            {
            _env = env;
        }

        public async Task<List<User>> GetUsersAsync() //  reads all user data from the JSON file
        {
            var filePath = Path.Combine(_env.WebRootPath, _filePath); // constructs full file path
            if (!File.Exists(filePath)) // checks if file exists
            {
                return new List<User>(); // returns empty list if file doesn't exist
            }

            try
            {
                var jsonString = await File.ReadAllTextAsync(filePath);// reads the JSON file content
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // To handle case differences if any
                };
                var users = JsonSerializer.Deserialize<List<User>>(jsonString, options);
                return users ?? new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading users.json: {ex.Message}");
                return new List<User>();
            }
        }

        public async Task<User> AuthenticateUserAsync(string username, string password) // Authenticates a user based on username and password
        {
            var users = await GetUsersAsync();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password); // finds a user with matching credentials
        }
    }
}