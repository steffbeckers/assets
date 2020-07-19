using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assets.Infrastructure.Persistence.Migrations
{
    public partial class IdentityTablesRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
