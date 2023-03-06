
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Sis_UserV2.Mapping;

namespace Sis_UserV2
{
    public class ApplicationDbContext : DbContext
    {
        private string _conn = "Server=192.168.0.21;Database=Regularizacao_Fundi;Port=5432;UID=postgres;Password=a";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigurarRelacionamentoEntidades(DeleteBehavior.ClientSetNull);
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new Auth_UserMapping());
            builder.ApplyConfiguration(new Fone_UserMapping());
            builder.ApplyConfiguration(new Endereco_UserMapping());
            builder.ApplyConfiguration(new Doc_UserMapping());
            builder.ApplyConfiguration(new Image_UserMapping());
            builder.ApplyConfiguration(new Keyword_UserMapping());
            builder.ConfigurarServidorBancoDados();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigurarConexao( _conn);
        }
    }
}
