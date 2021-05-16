using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructures.Migrations
{
    public partial class oncascadeAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_task_TaskUser",
                table: "TaskUser");

            migrationBuilder.DropForeignKey(
                name: "FK_User_TaskUser",
                table: "TaskUser");

            migrationBuilder.AddForeignKey(
                name: "FK_task_TaskUser",
                table: "TaskUser",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TaskUser",
                table: "TaskUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_task_TaskUser",
                table: "TaskUser");

            migrationBuilder.DropForeignKey(
                name: "FK_User_TaskUser",
                table: "TaskUser");

            migrationBuilder.AddForeignKey(
                name: "FK_task_TaskUser",
                table: "TaskUser",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TaskUser",
                table: "TaskUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
