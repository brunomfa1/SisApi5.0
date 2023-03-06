using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_UserV2.Models;

namespace Sis_UserV2.Mapping
{
    public class Image_UserMapping : IEntityTypeConfiguration<Image_User>
    {
        public Image_UserMapping()
        {

        }
        public void Configure(EntityTypeBuilder<Image_User> builder)
        {
            builder.ToTable("Image_User");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.CPF).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Img).HasMaxLength(int.MaxValue);


        }
    }
}
