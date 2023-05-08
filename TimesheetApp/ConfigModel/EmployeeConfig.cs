
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimesheetApp.Model;

namespace TimesheetApp.ConfigModel
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.PersonnelCode);
            builder.Property(b => b.FirstName);
            builder.Property(b => b.LastName);

            builder.HasOne(b => b.Shift)
                .WithMany(b => b.Employees)
                .HasForeignKey(b => b.ShiftId)
                .IsRequired();           
        }
    }

}
