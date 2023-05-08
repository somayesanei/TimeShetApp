using Microsoft.EntityFrameworkCore;
using System.Text;
using TimesheetApp.Context;
using TimesheetApp.DTO;
using TimesheetApp.Model;
using TimesheetApp.Repository;

namespace TimesheetApp.Service
{
    public class TimeSheetService : ITimeSheetService
    {
        private IEmployeeRepository _employeeRepository;
        private ITimeSheetRepository _timeSheetRepository;
        public TimeSheetService(IEmployeeRepository employeeRepository, ITimeSheetRepository timeSheetRepository)
        {
            _employeeRepository = employeeRepository;
            _timeSheetRepository = timeSheetRepository;
        }
        public TimeSheetResponse GetTimesheet(int employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);
            var employeeShift = _employeeRepository.GetEmployeeShift(employeeId);
            var employeeTimes = _timeSheetRepository.GetTimesheet(employeeId);

            var timesheetList = new TimeSheetResponse
            {
                EmpoyeeId = employee.Id,
                EmpoyeeName = employee.FirstName + ' ' + employee.LastName
            };
            timesheetList.EmpoyeeId = employeeId;
            var dateTimes = employeeTimes.GroupBy(x => x.RegisterDate);

            foreach (var timesheet in dateTimes)
            {
                var timeInDays = new List<TimeInDay>();
                var orderedTimes = timesheet.OrderBy(x => x.StartTime);
                StringBuilder timeSheetInDay = new StringBuilder();

                foreach (var time in orderedTimes)
                {
                    if (time.TimeType == EnumTimeType.SHIFT)
                        timeSheetInDay.Append("--" + EnumTimeType.SHIFT.ToString() + ": " + time.StartTime + " to " + time.EndTime);

                    if (time.TimeType == EnumTimeType.BREAK)
                        timeSheetInDay.Append("--" + EnumTimeType.BREAK.ToString() + ": " + time.StartTime + " to " + time.EndTime);

                    if (time.TimeType == EnumTimeType.LEAVE)
                    {
                        var str = CheckLeaveTime(employeeShift, timeSheetInDay, time);
                        timeSheetInDay.Append(str);
                    }
                }
                var timesInDay = new TimeInDay
                {
                    RegisterDate = timesheet.Key,
                    TimesInDay = timeSheetInDay.ToString()
                };
                timeInDays.Add(timesInDay);
                timesheetList.TimeInDays = timeInDays;
            }

            return timesheetList;
        }
        private string CheckLeaveTime(Shift employeeShift, StringBuilder timeSheetInDay, TimeSheet time)
        {
            var startLeaveTime = time.StartTime;
            var endLeaveTime = time.EndTime;
            if (time.StartTime <= employeeShift.StartTime)
                startLeaveTime = employeeShift.StartTime;

            if (time.EndTime >= employeeShift.EndTime)
                endLeaveTime = employeeShift.EndTime;

            var leaveStr = "--" + EnumTimeType.LEAVE.ToString() + ": " + startLeaveTime + " to " + endLeaveTime;
            return leaveStr;
        }
    }
}
