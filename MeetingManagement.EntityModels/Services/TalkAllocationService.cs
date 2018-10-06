using MeetingManagement.EntityModels.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManagement.EntityModels.Services
{
    public class TalkAllocationService : ITalkAllocationService
    {
        public List<Track> _tracks;
        public List<Talk> _talks;
        private int _unAllocatedTime;

        public TalkAllocationService()
        {

        }
      public async Task<IList<Track>> CreateTracksFromTalks(IList<Talk> talks)
        {
            _tracks = new List<Track>();
            int totalDuration = talks.Sum(item => item.Duration.TalkLength * (int)(item.Duration.TalkLengthType));
            // Get Number of tracks from total minutes & lighting in talks: A track has 7hrs of talks
            int totalTracks = totalDuration / 420;
            for (int i = 1; i <= totalTracks; i++)
            {
                var track = new Track
                {
                    Id = Guid.NewGuid(),
                    TrackName = $"Track {i}",
                    MorningSession = new TrackSession()
                    {
                        Talks = new List<Talk>(),
                        SessionName = "Morning Session",
                        Start = new TimeSpan(09, 00, 00),
                        End = new TimeSpan(12, 00, 00)

                    },
                    AfternoonSession = new TrackSession()
                    {
                        Talks = new List<Talk>(),
                        SessionName = "Afternoon Session",
                        Start = new TimeSpan(13, 00, 00),
                        End = new TimeSpan(17, 00, 00)
                    },
                    Networking = new Networking()
                    {
                        Title = "Networking Event",
                        Start = new TimeSpan(17, 00, 00),
                        //                        End = new TimeSpan(17, 00, 00)
                    },
                    LunchBreak = new LunchBreak()
                    {
                        Title = "Lunch Break",
                        Start = new TimeSpan(12, 00, 00),
                        End = new TimeSpan(13, 00, 00)
                    }
                };
                track.MorningSession.SessionUnAllocatedTime =
                    track.MorningSession.End.Subtract(track.MorningSession.Start);
                track.AfternoonSession.SessionUnAllocatedTime =
                    track.AfternoonSession.End.Subtract(track.AfternoonSession.Start);
                _tracks.Add(track);
            }
            return _tracks;
        }
        public async Task<List<Talk>> RegisterTalks(IList<Talk> talks)
        {
            _talks = new List<Talk>();
            foreach (var talk in talks)
            {
                _talks.Add(talk);
            }
            return _talks;
        }
        public async Task<Meeting> CreateMeeting(IList<Talk> talks)
        {
            await CreateTracksFromTalks(talks);
            await RegisterTalks(talks);
            ShuffleTalks();
            ComputeSessionUnAllocatedTime();
            for (var i = 0; i < _talks.Count; i++)
            {
                Talk talk = _talks[i];
                if (!AllocateTalkToMorningSession(talk).Result)
                {
                    await AllocateTalkToAfternoonSession(talk);
                }
                AllocateNetworkingEvent();
            }

            Meeting meeting = new Meeting
            {
                Tracks = _tracks
            };
            return await AssignStartingAndEnding(meeting);
        }
        public async Task<Meeting> AssignStartingAndEnding(Meeting meeting)
        {
            for (int i = 0; i < meeting.Tracks.Count; i++)
            {
                Track track = meeting.Tracks[i];
                var trackStartMorningSession = track.MorningSession.Start;
                var trackStartAfternoonSessionStart = track.AfternoonSession.Start;
                for (var index = 0; index < track.MorningSession.Talks.Count; index++)
                {
                    Talk talk = track.MorningSession.Talks[index];
                    talk.Start = trackStartMorningSession;
                    trackStartMorningSession = trackStartMorningSession.Add(new TimeSpan(0, talk.Duration.TalkLength * (int)talk.Duration.TalkLengthType, 0));

                }
                for (int index = 0; index < track.AfternoonSession.Talks.Count; index++)
                {
                    var talk = track.AfternoonSession.Talks[index];
                    talk.Start = trackStartAfternoonSessionStart;
                    trackStartAfternoonSessionStart = trackStartAfternoonSessionStart.Add(new TimeSpan(0, talk.Duration.TalkLength * (int)talk.Duration.TalkLengthType, 0));
                }
            }

            return meeting;
        }
        public async Task<bool> AllocateTalkToMorningSession(Talk talk)
        {
            for (int i = 0; i < _tracks.Count; i++)
            {
                Track track = _tracks[i];
                var trackstarttime = track.MorningSession.Start;

                var minutes = talk.Duration.TalkLength * (int)(talk.Duration.TalkLengthType);
                if (minutes <= track.MorningSession.SessionUnAllocatedTime.TotalMinutes)
                {
                    talk.Start = trackstarttime.Add(new TimeSpan(0, talk.Duration.TalkLength * (int)talk.Duration.TalkLengthType, 0));
                    track.MorningSession.Talks.Add(talk);
                    track.MorningSession.SessionUnAllocatedTime = track.MorningSession
                        .SessionUnAllocatedTime.Subtract(new TimeSpan(0, minutes, 0));
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> AllocateTalkToAfternoonSession(Talk talk)
        {
            for (var i = 0; i < _tracks.Count; i++)
            {
                Track track = _tracks[i];
                var trackstarttime = track.AfternoonSession.Start;
                var minutes = talk.Duration.TalkLength * (int)(talk.Duration.TalkLengthType);
                if (minutes <= track.AfternoonSession.SessionUnAllocatedTime.TotalMinutes)
                {
                    talk.Start = trackstarttime.Add(new TimeSpan(0, talk.Duration.TalkLength * (int)talk.Duration.TalkLengthType, 0));
                    track.AfternoonSession.Talks.Add(talk);
                    track.AfternoonSession.SessionUnAllocatedTime = track.AfternoonSession
                        .SessionUnAllocatedTime.Subtract(new TimeSpan(0, minutes, 0));
                    return true;
                }
            }

            return false;
        }

        public void AllocateNetworkingEvent()
        {

            foreach (var track in _tracks)
            {
                track.Networking.Start = track.AfternoonSession.End.Subtract(track.AfternoonSession.SessionUnAllocatedTime);
            }
        }

        public void ComputeSessionUnAllocatedTime()
        {
            foreach (var track in _tracks)
            {
                _unAllocatedTime += (int)track.MorningSession.End.Subtract(track.MorningSession.Start).TotalMinutes;
                _unAllocatedTime += (int)track.AfternoonSession.End.Subtract(track.AfternoonSession.Start).TotalMinutes;
            }
        }

        public void ShuffleTalks()
        {
            Random random = new Random();
            int count = _talks.Count;
            while (count > 1)
            {
                count--;
                int index = random.Next(count + 1);
                Talk talk = _talks[index];
                _talks[index] = _talks[count];
                _talks[count] = talk;
            }

        }
    }
}
