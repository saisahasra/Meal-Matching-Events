using System.ComponentModel.DataAnnotations.Schema;

namespace DDD_work.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;  // Stores the event date
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        public long? UserID { get; set; }

        public List<long> Attendees { get; set; } = new List<long>();

        public TimeOnly? Time { get; set; }

    }
}

