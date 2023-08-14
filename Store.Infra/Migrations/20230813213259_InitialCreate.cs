using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL(18,0)", maxLength: 60, nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "INT", maxLength: 60, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(18,0)", maxLength: 60, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
