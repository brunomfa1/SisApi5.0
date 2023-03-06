using Core.Enumerador;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public static class ConfigOptionsBuilderExtenstions
    {
        public static DbContextOptionsBuilder ConfigurarConexao(this DbContextOptionsBuilder optionsBuilder, 
                                                                string stringConexao)
        {
                    return optionsBuilder
                        .UseNpgsql(stringConexao,
                        x => x.UseNetTopologySuite()
                        .SetPostgresVersion(new System.Version(12,0))
                        );
        }
    }
}
