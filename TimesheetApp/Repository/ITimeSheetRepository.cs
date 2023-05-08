
using TimesheetApp.DTO;
using TimesheetApp.Model;

namespace TimesheetApp.Repository
{
    public interface ITimeSheetRepository
    {
        List<TimeSheet> GetTimesheet(int employeeId);
    }
}
