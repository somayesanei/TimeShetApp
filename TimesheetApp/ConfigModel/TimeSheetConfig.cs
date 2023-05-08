
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimesheetApp.Model;

namespace TimesheetApp.ConfigModel
{
    public class TimeSheetConfig : IEntityTypeConfiguration<TimeSheet>
    {
        public void Configure(EntityTypeBuilder<TimeSheet> builder)
        {
            builder.ToTable("TimeSheet", "dbo");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.EmployeeId);
            builder.Property(s => s.StartTime);
            builder.Property(b => b.EndTime);
            builder.Property(b => b.TimeType);
            builder.Property(b => b.RegisterDate);

            builder.HasOne(b => b.Employee)
              .WithMany(b => b.timeSheets)
              .HasForeignKey(b => b.EmployeeId)
              .IsRequired();
        }
    }

}
