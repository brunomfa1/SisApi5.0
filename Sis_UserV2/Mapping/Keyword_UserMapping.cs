using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_UserV2.Models;

namespace Sis_UserV2.Mapping
{
    public class Keyword_UserMapping : IEntityTypeConfiguration<Keyword_User>
    {
        public Keyword_UserMapping()
        {

        }
        public void Configure(EntityTypeBuilder<Keyword_User> builder)
        {
            builder.ToTable("Keyword_User");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.CPF).HasMaxLength(int.MaxValue); ;
            builder.Property(b => b.KeyWord).HasMaxLength(int.MaxValue); ;
        }
    }
}
