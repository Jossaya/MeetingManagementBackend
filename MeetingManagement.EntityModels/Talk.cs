using System;
using System.Text.RegularExpressions;

namespace MeetingManagement.EntityModels
{
    public class Talk : BaseEntityModel
    {
        public Guid Id { get; set; }
        public virtual TalkDuration Duration { get; set; }
        public Talk(Guid id, string title, TalkDuration duration)
        {
            try
            {
                Id = id;
                Duration = duration;
                if (!Regex.IsMatch(title, @"[0-9]+"))
                    Title = title;
                else
                    throw new ArgumentException("Numeric values are not allowed in talk title");
            }
            catch (ArgumentException exception)
            {
                throw;
            }

        }

        public Talk()
        {
            
        }
    }
}
