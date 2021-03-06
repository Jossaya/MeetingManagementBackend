using System;
using System.Collections.Generic;
using MeetingManagement.EntityModels;
using MeetingManagement.EntityModels.Data;
using MeetingManagement.EntityModels.Enums;
using MeetingManagement.EntityModels.Services;
using MeetingManagement.EntityModels.Services.Interfaces;
using Xunit;

namespace MeetingManagement.UnitTests
{
    public class TalkAllocationTest
    {
        TalksRepository _talksRepository;
        private ITalkAllocationService _service;
        List<Track> _tracks;
        [Fact(DisplayName = "[TalkAllocationService : CreateTracksFromTalks] Should create tracks from talks  and return a list of tracks ")]
        public async void CreateTracks()
        {
            // arrange
            _tracks = new List<Track>();
            _talksRepository = new TalksRepository();
            _service = new TalkAllocationService();
            // act
            _tracks = (List<Track>)await _service.CreateTracksFromTalks(_talksRepository.TestInput);
            // assert
            Assert.NotNull(_tracks);
        }
        [Fact(DisplayName = "[TalkAllocationService : RegisterTalks] Should register talks and return a list of talks, A talk title should not have numeric values ")]
        public async void RegisterTalks()
        {
            // arrange
            var talks = new List<Talk>
            {

                new Talk(Guid.NewGuid(),  "Writing Fast Tests Against Enterprise Rails", new TalkDuration{ TalkLength =60, TalkLengthType=TalkLengthTypeEnum.Minutes }),
                new Talk(Guid.NewGuid(),  "Overdoing it in Python", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Lua for the Masses", new TalkDuration{ TalkLength=30,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Ruby Errors from Mismatched Gem Versions", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Common Ruby Errors", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Rails for Python Developers lightning", new TalkDuration{ TalkLength=35,TalkLengthType=TalkLengthTypeEnum.Lightning}),
                new Talk(Guid.NewGuid(),  "Communicating Over Distance", new TalkDuration{ TalkLength=60,TalkLengthType=TalkLengthTypeEnum.Minutes}),
                new Talk(Guid.NewGuid(),  "Accounting-Driven Development", new TalkDuration{ TalkLength=45,TalkLengthType=TalkLengthTypeEnum.Minutes}),

                };
            _service = new TalkAllocationService();
            // act
            var registeredtalksList = (List<Talk>)await _service.RegisterTalks(talks);
            // assert
            Assert.NotNull(registeredtalksList);
            Assert.Equal(talks.Count, registeredtalksList.Count);
        }
        [Fact(DisplayName = "[TalkAllocationService : CreateMeeting] Should allocate talks time and return a list of allocated talks to a track in a meeting")]
        public async void AllocateTalks()
        {
            // arrange
            _talksRepository = new TalksRepository();
            _service = new TalkAllocationService();
            // act
            var meeting = await _service.CreateMeeting(_talksRepository.TestInput);
            // assert
            Assert.NotNull(meeting);
        }
        [Fact(DisplayName = "[TalkAllocationService : RegisterTalkWithInvalidTitle] Numeric values are not allowed in talk title")]
        public async void RegisterTalkWithInvalidTitle()
        {
            // arrange
            var Title = "Writing Fast Tests Against Enterprise Rails: 60min";
            var Duration = new TalkDuration { TalkLength = 60, TalkLengthType = TalkLengthTypeEnum.Minutes };
            //act
            void action() => new Talk(Guid.NewGuid(),Title, Duration);
            //assert
            Assert.Throws<ArgumentException>((Action)action);
        }
    }
}
