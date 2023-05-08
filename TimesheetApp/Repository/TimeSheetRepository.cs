using TimesheetApp.Context;
using TimesheetApp.Model;

namespace TimesheetApp.Repository
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public TimeSheetRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<TimeSheet> GetTimesheet(int employeeId)
        {
            return _unitOfWork.Set<TimeSheet>().Where(x => x.EmployeeId == employeeId).ToList();
        }
    }
}
