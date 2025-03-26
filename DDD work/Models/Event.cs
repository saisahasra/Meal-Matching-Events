namespace DDD_work.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; } 
    }
}