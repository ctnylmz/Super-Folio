using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateTestimonialForAddDescriptionandEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Testimonials",
                newName: "Email");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Testimonials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Testimonials",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Testimonials");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Testimonials",
                newName: "Comment");
        }
    }
}
