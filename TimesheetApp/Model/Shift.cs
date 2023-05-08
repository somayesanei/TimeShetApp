namespace TimesheetApp.Model
{
    public class Shift
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
