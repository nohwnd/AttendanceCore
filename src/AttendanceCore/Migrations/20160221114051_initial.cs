using System;
using Microsoft.Data.Entity.Migrations;

namespace AttendanceCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("AspNetUsers", table => new
            {
                Id = table.Column<string>(nullable: false),
                AccessFailedCount = table.Column<int>(nullable: false),
                ConcurrencyStamp = table.Column<string>(nullable: true),
                Email = table.Column<string>(nullable: true),
                EmailConfirmed = table.Column<bool>(nullable: false),
                LockoutEnabled = table.Column<bool>(nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                NormalizedEmail = table.Column<string>(nullable: true),
                NormalizedUserName = table.Column<string>(nullable: true),
                PasswordHash = table.Column<string>(nullable: true),
                PhoneNumber = table.Column<string>(nullable: true),
                PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                SecurityStamp = table.Column<string>(nullable: true),
                TwoFactorEnabled = table.Column<bool>(nullable: false),
                UserName = table.Column<string>(nullable: true)
            },
                constraints: table => { table.PrimaryKey("PK_ApplicationUser", x => x.Id); });
            migrationBuilder.CreateTable("AspNetRoles", table => new
            {
                Id = table.Column<string>(nullable: false),
                ConcurrencyStamp = table.Column<string>(nullable: true),
                Name = table.Column<string>(nullable: true),
                NormalizedName = table.Column<string>(nullable: true)
            },
                constraints: table => { table.PrimaryKey("PK_IdentityRole", x => x.Id); });
            migrationBuilder.CreateTable("AspNetUserClaims", table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ClaimType = table.Column<string>(nullable: true),
                ClaimValue = table.Column<string>(nullable: true),
                UserId = table.Column<string>(nullable: false)
            },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey("FK_IdentityUserClaim<string>_ApplicationUser_UserId", x => x.UserId, "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable("AspNetUserLogins", table => new
            {
                LoginProvider = table.Column<string>(nullable: false),
                ProviderKey = table.Column<string>(nullable: false),
                ProviderDisplayName = table.Column<string>(nullable: true),
                UserId = table.Column<string>(nullable: false)
            },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey("FK_IdentityUserLogin<string>_ApplicationUser_UserId", x => x.UserId, "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable("AspNetRoleClaims", table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ClaimType = table.Column<string>(nullable: true),
                ClaimValue = table.Column<string>(nullable: true),
                RoleId = table.Column<string>(nullable: false)
            },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey("FK_IdentityRoleClaim<string>_IdentityRole_RoleId", x => x.RoleId, "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable("AspNetUserRoles", table => new
            {
                UserId = table.Column<string>(nullable: false),
                RoleId = table.Column<string>(nullable: false)
            },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new {x.UserId, x.RoleId});
                    table.ForeignKey("FK_IdentityUserRole<string>_IdentityRole_RoleId", x => x.RoleId, "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey("FK_IdentityUserRole<string>_ApplicationUser_UserId", x => x.UserId, "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex("EmailIndex", "AspNetUsers", "NormalizedEmail");
            migrationBuilder.CreateIndex("UserNameIndex", "AspNetUsers", "NormalizedUserName");
            migrationBuilder.CreateIndex("RoleNameIndex", "AspNetRoles", "NormalizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("AspNetUsers");
        }
    }
}