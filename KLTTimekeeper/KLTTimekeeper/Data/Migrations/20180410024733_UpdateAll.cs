using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KLTTimekeeper.Data.Migrations
{
    public partial class UpdateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateCreated",
                table: "Project",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateDue",
                table: "Project",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "projectName",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CourseName = table.Column<string>(nullable: true),
                    InstructorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CourseID",
                table: "Project",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ApplicationUserId",
                table: "Course",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Course_CourseID",
                table: "Project",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Course_CourseID",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Project_CourseID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "dateCreated",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "dateDue",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "projectName",
                table: "Project");
        }
    }
}
