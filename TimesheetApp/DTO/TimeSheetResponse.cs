namespace TimesheetApp.DTO
{
    public class TimeSheetResponse
    {
        public int EmpoyeeId { get; set; }
        public string EmpoyeeName { get; set; }
        public List<TimeInDay> TimeInDays { get; set; }
    }
    public class TimeInDay
    {
        public string TimesInDay { get; set; }
        public DateTime  RegisterDate { get; set; }
    }

}
