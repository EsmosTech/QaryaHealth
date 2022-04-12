using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QaryaHealth.Core.Entities;

namespace QaryaHealth.Infrastructure.EntityConfiguration
{
    public class LabConfiguration : IEntityTypeConfiguration<Lab>
    {
        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            builder.ToTable("lab");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(x => x.IsActive)
                .HasColumnName("isActive");

            builder.Property(x => x.ImageId)
                .HasColumnName("image-id");

            builder.Property(x => x.WorkingDays)
              .HasColumnName("working-days");

            builder.Property(x => x.StartWorkingHour)
              .HasColumnName("start-working-hour");

            builder.Property(x => x.EndWorkingHour)
              .HasColumnName("end-working-hour");

            builder.Property(x => x.UserId)
              .HasColumnName("user-id");

            builder.HasOne(r => r.User)
                .WithMany(r => r.Labs)
                .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Image)
                .WithMany(r => r.Labs)
                .HasForeignKey(r => r.ImageId);
        }
    }
}
