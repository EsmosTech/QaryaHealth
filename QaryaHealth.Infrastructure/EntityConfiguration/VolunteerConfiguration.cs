using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QaryaHealth.Core.Entities;

namespace QaryaHealth.Infrastructure.EntityConfiguration
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteer");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(x => x.IsActive)
                .HasColumnName("isActive");

            builder.Property(x => x.BirthDate)
              .HasColumnName("birth-date")
              .IsRequired();

            builder.Property(x => x.BloodType)
              .HasColumnName("blood-type")
              .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user-id");

            builder.HasOne(r => r.User)
                .WithMany(r => r.Volunteers)
                .HasForeignKey(r => r.UserId);
        }
    }
}
