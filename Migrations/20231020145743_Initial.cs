﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userData",
                columns: table => new
                {
                    userID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userData", x => x.userID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userData_userID",
                table: "userData",
                column: "userID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userData_UserName",
                table: "userData",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userData");
        }
    }
}
