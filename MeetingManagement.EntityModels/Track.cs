using System;

namespace MeetingManagement.EntityModels
{
    public class Track
    {
        public Guid Id { get; set; }
        public string TrackName { get; set; }
        public virtual TrackSession MorningSession { get; set; }
        public virtual TrackSession AfternoonSession { get; set; }
        public virtual Networking Networking { get; set; }
        public virtual LunchBreak LunchBreak { get; set; }
    }
}
