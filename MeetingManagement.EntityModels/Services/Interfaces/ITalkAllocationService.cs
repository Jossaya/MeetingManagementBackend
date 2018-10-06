using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingManagement.EntityModels.Services.Interfaces
{
    interface ITalkAllocationService
    {
        Task<IList<Track>> CreateTracksFromTalks(IList<Talk> talks);
        Task<List<Talk>> RegisterTalks(IList<Talk> talks);
        Task<Meeting> CreateMeeting(IList<Talk> talks);
        Task<Meeting> AssignStartingAndEnding(Meeting meeting);
        Task<bool> AllocateTalkToMorningSession(Talk talk);
        Task<bool> AllocateTalkToAfternoonSession(Talk talk);
        void AllocateNetworkingEvent();
        void ComputeSessionUnAllocatedTime();
        void ShuffleTalks();
    }
}
