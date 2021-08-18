using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterTechDMO.API.Migrations
{
    public partial class Add_Goals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMOGoal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    InsDT = table.Column<DateTime>(nullable: false),
                    UpdDT = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMOGoal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMOGoal");
        }
    }
}
