using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jcf.Control.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitailMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Login = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreateId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserUpdateId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "IsActive", "Login", "Name", "Password", "Role", "UpdateAt", "UserCreateId", "UserUpdateId" },
                values: new object[,]
                {
                    { new Guid("08dbd59a-2683-4c67-8e16-689ba2648545"), new DateTime(2025, 6, 8, 19, 29, 42, 893, DateTimeKind.Utc).AddTicks(5798), "admin@email.com", true, "admin@email.com", "Administrador Usuário", "670F8574BD93DD78BD568DAB84C6733A", "ADMIN", null, null, null },
                    { new Guid("08dbdc08-56e1-4e90-805f-db29361e075e"), new DateTime(2025, 6, 8, 19, 29, 42, 893, DateTimeKind.Utc).AddTicks(6614), "basico@email.com", true, "basico@email.com", "Básico Usuário", "670F8574BD93DD78BD568DAB84C6733A", "BASIC", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCreateId",
                table: "Users",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserUpdateId",
                table: "Users",
                column: "UserUpdateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
