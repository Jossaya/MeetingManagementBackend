using System;

namespace MeetingManagement.EntityModels
{
    public class BaseEntityModel
    {
        public string Title { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
