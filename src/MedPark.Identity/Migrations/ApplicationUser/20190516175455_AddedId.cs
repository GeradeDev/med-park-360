using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Identity.Migrations.ApplicationUser
{
    public partial class AddedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "AspNetUsers");
        }
    }
}
