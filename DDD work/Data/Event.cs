namespace DDD_work.Data
{
    public class Event
    {
        public int Id { get; set; } // unique identifier for the event
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<long> Rsvps { get; set; } = new List<long>(); // List of User IDs who have RSVP'd
    }
}