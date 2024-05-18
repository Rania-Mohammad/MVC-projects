using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectF.Migrations
{
    /// <inheritdoc />
    public partial class login3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "login");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "login",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
