using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpassoCasa_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Produtos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URLImagem",
                table: "Produtos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLImagem",
                table: "Produtos");
        }
    }
}
