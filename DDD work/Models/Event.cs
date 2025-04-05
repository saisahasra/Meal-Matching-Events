using System.ComponentModel.DataAnnotations.Schema;

namespace DDD_work.Models
{
    //public class Event
    //{
    //    public long Id { get; set; }
    //    public string? Name { get; set; }
    //    public DateTime DateTime { get; set; }
    //    public DateTime Date { get; set; } = DateTime.Today;

    //    public string? Location { get; set; }
    //    public string? Description { get; set; }
    //    public string? PictureUrl { get; set; }
    //    public long? UserID { get; set; }

    //    public List<long> Attendees { get; set; } = new List<long>();


    //        public TimeOnly? Time { get; set; }  // Use TimeOnly for time selection

    //        [NotMapped]  // Prevents EF Core from mapping it to the database
    //        public string TimeString
    //        {
    //            get => Time?.ToString("HH:mm") ?? string.Empty;
    //            set => Time = TimeOnly.TryParse(value, out var time) ? time : null;
    //        }

    //        public DateTime DateTime => Date.Add(Time?.ToTimeSpan() ?? TimeSpan.Zero);


    //}



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

