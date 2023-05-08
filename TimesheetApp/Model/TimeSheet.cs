namespace TimesheetApp.Model
{
    public class TimeSheet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public EnumTimeType TimeType { get; set; }
        public DateTime RegisterDate { get; set; }
        public Employee Employee { get; set; }
    }
}
