using Microsoft.AspNetCore.Mvc;
using TimesheetApp.DTO;
using TimesheetApp.Service;

namespace TimesheetApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSheetController : ControllerBase
    {       

        private readonly ITimeSheetService _timeSheetService;
        public TimeSheetController(ITimeSheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
        }

        [HttpGet(Name = "TimeSheet/{employeeId}/")]
        public IActionResult Get(int employeeId)
        {
            var respons = _timeSheetService.GetTimesheet(employeeId);
            return Ok(respons);
        }
    }
}