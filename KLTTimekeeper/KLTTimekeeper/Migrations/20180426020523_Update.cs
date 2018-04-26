using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KLTTimekeeper.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeCard_Member_MemberID",
                table: "TimeCard");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "TimeCard",
                newName: "GroupMemberMemberID");

            migrationBuilder.RenameIndex(
                name: "IX_TimeCard_MemberID",
                table: "TimeCard",
                newName: "IX_TimeCard_GroupMemberMemberID");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Group",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isInstructor",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CourseMember",
                columns: table => new
                {
                    CourseMemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMember", x => x.CourseMemberID);
                    table.ForeignKey(
                        name: "FK_CourseMember_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMember_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_GroupMember_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_ApplicationUserId",
                table: "Group",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMember_ApplicationUserId",
                table: "CourseMember",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMember_CourseID",
                table: "CourseMember",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_GroupID",
                table: "GroupMember",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_AspNetUsers_ApplicationUserId",
                table: "Group",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeCard_GroupMember_GroupMemberMemberID",
                table: "TimeCard",
                column: "GroupMemberMemberID",
                principalTable: "GroupMember",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_AspNetUsers_ApplicationUserId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeCard_GroupMember_GroupMemberMemberID",
                table: "TimeCard");

            migrationBuilder.DropTable(
                name: "CourseMember");

            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropIndex(
                name: "IX_Group_ApplicationUserId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isInstructor",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "GroupMemberMemberID",
                table: "TimeCard",
                newName: "MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_TimeCard_GroupMemberMemberID",
                table: "TimeCard",
                newName: "IX_TimeCard_MemberID");

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Member_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_GroupID",
                table: "Member",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeCard_Member_MemberID",
                table: "TimeCard",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
