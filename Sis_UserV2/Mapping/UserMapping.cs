using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_UserV2.Models;

namespace Sis_UserV2.Mapping

{
    public class UserMapping: IEntityTypeConfiguration<User>
    {
        public UserMapping()
        {

        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.CPF).HasMaxLength(int.MaxValue);
            builder.Property(b => b.RG).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Email).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Observacao).HasMaxLength(int.MaxValue);
;        }
    } 
}
