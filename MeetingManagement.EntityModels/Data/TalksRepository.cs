using System;
using System.Collections.Generic;
using MeetingManagement.EntityModels.Enums;

namespace MeetingManagement.EntityModels.Data
{
    public class TalksRepository
    {
        public List<string> TestStringInput { get; set; }
        public List<Talk> TestInput { get; set; }
        public TalksRepository()
        {
            TestStringInput = new List<string>()
            {
                "Writing Fast Tests Against Enterprise Rails: 60min",
                "Overdoing it in Python: 45min",
                "Lua for the Masses: 30min",
                "Ruby Errors from Mismatched Gem Versions: 45min",
                "Common Ruby Errors: 45min",
                "Rails for Python Developers lightning: 35min",
                "Communicating Over Distance: 60min",
                "Accounting-Driven Development: 45min",
                "Woah: 30min",
                "Sit Down and Write: 30min",
                "Pair Programming vs Noise: 45min",
                "Rails Magic: 60min",
                "Ruby on Rails: Why We Should Move On?: 60min",
                "Clojure Ate Scala (on my project): 45min",
                "Programming in the Boondocks of Seattle: 30min",
                "Ruby vs. Clojure for Back-End Development: 30min",
                "Ruby on Rails Legacy App Maintenance: 60min",
                "A World Without HackerNews: 30min",
                "User Interface CSS in Rails Apps: 30min"

            };
            TestInput = new List<Talk>()
            {

                new Talk(Guid.NewGuid(),  "Writing Fast Tests Against Enterprise Rails", new TalkDuration{ TalkLength =60, TalkLengthType=TalkLengthTypeEnum.Minutes }),
                new Talk(Guid.NewGuid(),  "Overdoing it in Python", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Lua for the Masses", new TalkDuration{ TalkLength=30,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Ruby Errors from Mismatched Gem Versions", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Common Ruby Errors", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Rails for Python Developers lightning", new TalkDuration{ TalkLength=35,TalkLengthType=TalkLengthTypeEnum.Lightining}),
                new Talk(Guid.NewGuid(),  "Communicating Over Distance", new TalkDuration{ TalkLength=60,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Accounting-Driven Development", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Woah", new TalkDuration{ TalkLength=30,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Sit Down and Write", new TalkDuration{ TalkLength=30,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Pair Programming vs Noise", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Rails Magic", new TalkDuration{ TalkLength=60,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Ruby on Rails: Why We Should Move On?", new TalkDuration{ TalkLength=60,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Clojure Ate Scala (on my project)", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Programming in the Boondocks of Seattle", new TalkDuration{ TalkLength=30,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Ruby vs. Clojure for Back-End Development", new TalkDuration{ TalkLength=30,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Ruby on Rails Legacy App Maintenance", new TalkDuration{ TalkLength=60,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "A World Without HackerNews", new TalkDuration{ TalkLength=30,TalkLengthType=TalkLengthTypeEnum.Minutes }),
                new Talk(Guid.NewGuid(),  "User Interface CSS in Rails Apps", new TalkDuration{ TalkLength=30,TalkLengthType=TalkLengthTypeEnum.Minutes})

            };

        }
    }
}
