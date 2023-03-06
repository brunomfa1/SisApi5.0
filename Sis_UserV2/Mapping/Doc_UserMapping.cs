using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_UserV2.Models;

namespace Sis_UserV2.Mapping
{
    public class Doc_UserMapping : IEntityTypeConfiguration<Doc_User>
    {
        public Doc_UserMapping()
        {

        }
        public void Configure(EntityTypeBuilder<Doc_User> builder)
        {
            builder.ToTable("Doc_User");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.CPF).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Doc).HasMaxLength(int.MaxValue);



        }
    }
}
