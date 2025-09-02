using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViraRankApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(75)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    password = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Email_Unique",
                table: "USER",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserName_Unique",
                table: "USER",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
