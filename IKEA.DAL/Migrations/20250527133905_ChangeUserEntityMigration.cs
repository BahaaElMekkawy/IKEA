using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IKEA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserEntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonName",
                table: "AspNetUsers",
                newName: "Lname");

            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAgree",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAgree",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Lname",
                table: "AspNetUsers",
                newName: "PersonName");
        }
    }
}
