using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TodoApi.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationID = table.Column<int>(type: "int", nullable: true),
                    _fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organizacionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventItems_OrganizationItems_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "OrganizationItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_OrganizationID",
                table: "EventItems",
                column: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventItems");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "OrganizationItems");
        }
    }
}
