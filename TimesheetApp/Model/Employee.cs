namespace TimesheetApp.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public int PersonnelCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public ICollection<TimeSheet> timeSheets { get; set; }
    }
}
