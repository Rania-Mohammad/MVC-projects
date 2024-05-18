using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectF.Migrations
{
    /// <inheritdoc />
    public partial class forgetdata5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "forgetDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "forgetDatas");
        }
    }
}
