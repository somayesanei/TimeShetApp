
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimesheetApp.Model;

namespace TimesheetApp.ConfigModel
{
    public class ShiftConfig : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable("Shift", "dbo");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title);
            builder.Property(b => b.StartTime);
            builder.Property(b => b.EndTime);

          
        }
    }

}
