using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViraRankApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordHashAndSalt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "password",
                table: "USER");

            migrationBuilder.RenameIndex(
                name: "UserName_Unique",
                table: "USER",
                newName: "UX_User_UserName");

            migrationBuilder.RenameIndex(
                name: "Email_Unique",
                table: "USER",
                newName: "UX_User_Email");

            migrationBuilder.AddColumn<byte[]>(
                name: "password_hash",
                table: "USER",
                type: "varbinary(64)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "password_salt",
                table: "USER",
                type: "varbinary(32)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "USER",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "USER");

            migrationBuilder.RenameIndex(
                name: "UX_User_UserName",
                table: "USER",
                newName: "UserName_Unique");

            migrationBuilder.RenameIndex(
                name: "UX_User_Email",
                table: "USER",
                newName: "Email_Unique");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "USER",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "USER",
                column: "Id");
        }
    }
}
