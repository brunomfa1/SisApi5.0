using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sis_UserV2.Migrations
{
    public partial class BL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auth_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Pass = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doc_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Doc = table.Column<byte[]>(type: "bytea", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doc_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Rua = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Bairro = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Quadra = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Lote = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    CEP = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Estado = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Cidade = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fone_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    FoneCelular1 = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    FoneCelular2 = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    FoneFixo = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fone_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Img = table.Column<byte[]>(type: "bytea", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keyword_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    KeyWord = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    RG = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Email = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true),
                    Observacao = table.Column<string>(type: "character varying", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth_User");

            migrationBuilder.DropTable(
                name: "Doc_User");

            migrationBuilder.DropTable(
                name: "Endereco_User");

            migrationBuilder.DropTable(
                name: "Fone_User");

            migrationBuilder.DropTable(
                name: "Image_User");

            migrationBuilder.DropTable(
                name: "Keyword_User");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
