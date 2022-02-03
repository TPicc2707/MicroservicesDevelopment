using Microsoft.EntityFrameworkCore.Migrations;

namespace Person.Infrastructure.Migrations
{
    public partial class AddRelationBetweenEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PeopleAddresses_Person_Id",
                table: "PeopleAddresses",
                column: "Person_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleAddresses_People_Person_Id",
                table: "PeopleAddresses",
                column: "Person_Id",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleAddresses_People_Person_Id",
                table: "PeopleAddresses");

            migrationBuilder.DropIndex(
                name: "IX_PeopleAddresses_Person_Id",
                table: "PeopleAddresses");
        }
    }
}
