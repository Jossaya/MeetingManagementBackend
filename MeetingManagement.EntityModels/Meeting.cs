using System.Collections.Generic;

namespace MeetingManagement.EntityModels
{
   public class Meeting
    {
        public virtual IList<Track> Tracks { get; set; }
        public Meeting()
        {
            Tracks = new List<Track>();
        }
    }
}
