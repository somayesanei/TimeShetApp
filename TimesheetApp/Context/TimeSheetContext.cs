using Microsoft.EntityFrameworkCore;
using TimesheetApp.ConfigModel;
using TimesheetApp.Model;

namespace TimesheetApp.Context
{
    public sealed class TimeSheetContext : DbContext, IUnitOfWork
    {
        public TimeSheetContext(DbContextOptions<TimeSheetContext> options) : base(options)
        {
          
        }      
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            SetMappings(builder);
        }
        private void SetMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShiftConfig());
            modelBuilder.ApplyConfiguration(new TimeSheetConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }
    }
}
