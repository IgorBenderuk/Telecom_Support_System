using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelecomSupportSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorAgentTicketRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AgentId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AgentProfiles_AgentId",
                table: "Tickets",
                column: "AgentId",
                principalTable: "AgentProfiles",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />  
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AgentProfiles_AgentId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AgentId",
                table: "Tickets",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
