using Core.Enumerador;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Context
{
    public static class ConfigModelBuilderExtensions
    {
        public static ModelBuilder ConfigurarServidorBancoDados(this ModelBuilder modelBuilder)
        {
                    foreach (var property in modelBuilder.Model.GetEntityTypes()
                        .SelectMany(e => e.GetProperties()
                        .Where(p => p.ClrType == typeof(string))))
                        property.SetColumnType("character varying");
                    return modelBuilder;
        }

        public static ModelBuilder ConfigurarRelacionamentoEntidades(this ModelBuilder modelBuilder, DeleteBehavior behavior)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = behavior;

            return modelBuilder;
        }
    }
}