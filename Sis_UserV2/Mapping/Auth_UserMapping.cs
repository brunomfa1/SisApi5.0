using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_UserV2.Models;

namespace Sis_UserV2.Mapping
{
    public class Auth_UserMapping : IEntityTypeConfiguration<Auth_User>
    {
        public Auth_UserMapping()
        {

        }

        public void Configure(EntityTypeBuilder<Auth_User> builder)
        {
            builder.ToTable("Auth_User");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.CPF).HasMaxLength(int.MaxValue); ;
            builder.Property(b => b.Pass).HasMaxLength(int.MaxValue); ;
        }
    }
}
