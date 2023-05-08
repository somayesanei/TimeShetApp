
using TimesheetApp.DTO;
using TimesheetApp.Model;

namespace TimesheetApp.Repository
{
    public interface IEmployeeRepository
    {
        Shift GetEmployeeShift(int EmployeeId);
        Employee GetById(int Id);
    }
}
