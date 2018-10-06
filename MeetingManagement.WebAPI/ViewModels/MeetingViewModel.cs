using System.Collections.Generic;
using MeetingManagement.EntityModels;

namespace MeetingManagement.WebAPI.ViewModels
{
    public class MeetingViewModel
    {
        public virtual Meeting TestOutput { get; set; }
        public virtual IList<string> TestInput { get; set; }
    }
}
