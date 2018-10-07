using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using MeetingManagement.EntityModels.Enums;

namespace MeetingManagement.EntityModels.Data
{
    public class TalksRepository
    {
        public List<string> TestStringInput { get; set; }
        public List<Talk> TestInput { get; set; }
        public TalksRepository()
        {
            TestInput= new List<Talk>();
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
            CultureInfo culture = CultureInfo.CurrentCulture;
            foreach (var stringInput in TestStringInput)
            {
             var talk=    new Talk(Guid.NewGuid(), stringInput.Substring(0, stringInput.IndexOf(":", StringComparison.Ordinal)),
                    new TalkDuration {TalkLength = culture.CompareInfo.IndexOf(stringInput, "lightning", CompareOptions.IgnoreCase) >= 0 ? (int)TalkLengthTypeEnum.Lightning : Convert.ToInt32(Regex.Match(stringInput, @"\d+").Value), TalkLengthType = culture.CompareInfo.IndexOf(stringInput, "lightning", CompareOptions.IgnoreCase) >= 0 ? TalkLengthTypeEnum.Lightning : TalkLengthTypeEnum.Minutes});
                TestInput.Add(talk);
            }


        }

    }
}
