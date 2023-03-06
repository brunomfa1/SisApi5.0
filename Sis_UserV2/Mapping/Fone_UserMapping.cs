using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_UserV2.Models;

namespace Sis_UserV2.Mapping
{
    public class Fone_UserMapping : IEntityTypeConfiguration< Fone_User>
    {
        public Fone_UserMapping()
        {

        }

        public void Configure(EntityTypeBuilder< Fone_User> builder)
        {
            builder.ToTable("Fone_User");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.CPF).HasMaxLength(int.MaxValue);
            builder.Property(b => b.FoneCelular1).HasMaxLength(int.MaxValue);
            builder.Property(b => b.FoneCelular2).HasMaxLength(int.MaxValue);
            builder.Property(b => b.FoneFixo).HasMaxLength(int.MaxValue);
        }
    }
}
