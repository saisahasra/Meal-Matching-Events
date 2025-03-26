using DDD_work.Models; 
using System.Security.Claims;
using System.Threading.Tasks;

namespace DDD_work.Services.Auth
{
    public class UserService // this service keeps track of the current logged-in user
    {
        private User _currentUser; // the currently logged-in user, private so we control it

        public User CurrentUser => _currentUser; // a way to get the current user info

        public void SetCurrentUser(User user) // when someone logs in, we set the current user
        {
            _currentUser = user; // store the user details
        }

        public void ClearCurrentUser() // when someone logs out
        {
            _currentUser = null; // clear the current user
        }

        public bool IsLoggedIn => _currentUser != null; // tells us if someone is logged in

        // more user-related methods here pls !!!

        // maybe get the current user's id?
        public long? GetCurrentUserId()
        {
            return _currentUser?.UserID; // if there's a user, give their id, otherwise null
        }

        // could get the current user's username too
        public string GetCurrentUsername()
        {
            return _currentUser?.Username; // same idea, but for the username
        }

        // maybe check if the current user has a certain role (if you have roles)
        // public bool IsInRole(string role)
        // {
        //     return _currentUser?.Claims?.Any(c => c.Type == ClaimTypes.Role && c.Value == role) ?? false;
        // }

        // you could also get the full name
        public string GetCurrentUserFullName()
        {
            return _currentUser?.FullName; // get the full name if it exists
        }

        // or maybe get their age
        public int? GetCurrentUserAge()
        {
            return _currentUser?.Age; // get the age if available
        }

        // a method to check if the current user is the same as a given user
        public bool IsCurrentUser(User user)
        {
            return _currentUser != null && _currentUser.UserID == user.UserID; // compare user ids
        }
    }
}