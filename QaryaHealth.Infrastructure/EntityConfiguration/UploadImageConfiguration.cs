using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QaryaHealth.Core.Entities;

namespace QaryaHealth.Infrastructure.EntityConfiguration
{
    public class UploadImageConfiguration : IEntityTypeConfiguration<UploadImage>
    {
        public void Configure(EntityTypeBuilder<UploadImage> builder)
        {
            builder.ToTable("upload-image");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(x => x.IsActive)
                .HasColumnName("isActive");

            builder.Property(x => x.Image)
                .HasColumnName("image");
        }
    }
}
