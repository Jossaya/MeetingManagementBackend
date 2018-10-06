using System;
using System.Collections.Generic;

namespace MeetingManagement.EntityModels
{
    public class TrackSession:BaseEntityModel
    {
        public string SessionName { get; set; }
        public int SessionDuration { get; set; }
        public TimeSpan AllocatedTime { get; set; }
        public TimeSpan SessionUnAllocatedTime { get; set; }
        public virtual List<Talk> Talks { get; set; }

        public TrackSession()
        {
            Talks =new List<Talk>();

        }
    }
}
