using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructures.Migrations
{
    public partial class oaddedObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskComment",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComment",
                table: "Comment",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskComment",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComment",
                table: "Comment",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
