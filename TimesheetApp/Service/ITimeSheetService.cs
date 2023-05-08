
using TimesheetApp.DTO;

namespace TimesheetApp.Service
{
    public interface ITimeSheetService
    {
        TimeSheetResponse GetTimesheet(int employeeId);
    }
}
