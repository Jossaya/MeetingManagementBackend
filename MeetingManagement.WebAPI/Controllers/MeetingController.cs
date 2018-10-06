using MeetingManagement.EntityModels.Data;
using MeetingManagement.EntityModels.Services;
using MeetingManagement.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeetingManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private TalksRepository _talksRepository;
        private TalkAllocationService _service;
        // GET api/meeting
        [HttpGet]
        public async Task<ActionResult<MeetingViewModel>> GetMeetingAsync()
        {

            _talksRepository = new TalksRepository();
            _service = new TalkAllocationService();


            var meeting = await _service.CreateMeeting(_talksRepository.TestInput);
            var meetingViewModel = new MeetingViewModel { TestInput = _talksRepository.TestStringInput, TestOutput = meeting };

            return meetingViewModel;
        }
    }
}