//namespace DDD_work.Models
//{
//    public class MealMatch
//    {
//        public int Id { get; set; }
//        public int UserId { get; set; }
//        public string Location { get; set; }
//        public string Visibility { get; set; }
//    }
//}

namespace DDD_work.Models
{
    //public class MealMatch
    //{
    //    public long Id { get; set; }
    //    public string Name { get; set; } // Add this if missing
    //    public string MealName { get; set; } // Ensure this exists
    //    public DateTime DateTime { get; set; }
    //    public string Location { get; set; }
    //    public string Description { get; set; }
    //    public string PictureUrl { get; set; }
    //    public long PostedByUserId { get; set; } // Ensure this matches Razor code
    //}

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


