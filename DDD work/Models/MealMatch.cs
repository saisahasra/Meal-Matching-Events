

namespace DDD_work.Models
{

    public enum VisibilityOption { Everyone, ConnectionsOnly }

    public class MealMatch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MealTime { get; set; }
        public string Description { get; set; }
        public int PosterUserId { get; set; }  // This is still needed for tracking
        public User PosterUser { get; set; }  // This will hold the full user details
        public VisibilityOption Visibility { get; set; }
        public string Location { get; set; }
        public int? AllowedUserId { get; set; }
    }




}
