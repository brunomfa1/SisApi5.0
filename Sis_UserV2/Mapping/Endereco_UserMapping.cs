using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_UserV2.Models;

namespace Sis_UserV2.Mapping
{
    public class Endereco_UserMapping : IEntityTypeConfiguration<Endereco_User>
    {
        public Endereco_UserMapping()
        {

        }

        public void Configure(EntityTypeBuilder<Endereco_User> builder)
        {
            builder.ToTable("Endereco_User");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.CPF).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Rua).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Bairro).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Quadra).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Lote).HasMaxLength(int.MaxValue);
            builder.Property(b => b.CEP).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Estado).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Cidade).HasMaxLength(int.MaxValue);

        }
    }
}