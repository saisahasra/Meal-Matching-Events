using DDD_work.Models;
using DDD_work.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DDD_work.Services.Auth
{
    public class UserService
    {
        private User _currentUser; // private field to store the current user

        public User CurrentUser => _currentUser; // public property to access the current user

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        public void ClearCurrentUser()
        {
            _currentUser = null;
        }

        public bool IsLoggedIn => _currentUser != null;

        // more user-related methods here pls !!!
    }
}