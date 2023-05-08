using Microsoft.EntityFrameworkCore;
using TimesheetApp.Context;
using TimesheetApp.Model;

namespace TimesheetApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Shift GetEmployeeShift(int employeeId)
        {
            var result = _unitOfWork.Set<Employee>()
                 .Include(x => x.Shift)
                 .Where(x => x.Id == employeeId)
                 .Select(x => x.Shift)
                 .FirstOrDefault();
            return result;
        }
        public Employee GetById(int Id)
        {
            var result = _unitOfWork.Set<Employee>().FirstOrDefault(x => x.Id == Id);
            return result;
        }


    }
}
