using MeetingManagement.EntityModels.Enums;

namespace MeetingManagement.EntityModels
{
    public class TalkDuration
    {
        public int TalkLength { get; set; }
        public virtual TalkLengthTypeEnum TalkLengthType { get; set; }
        public TalkDuration()
        {
            TalkLengthType = new TalkLengthTypeEnum();

        }
    }
}
