using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicwayCodeChallenge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    dob = table.Column<DateTime>(type: "date", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "id", "dob", "email", "firstName", "lastName" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTime(1999, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "otto.grissom@micway.com", "Otto", "Grissom" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new DateTime(1986, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "fredrick.janson@micway.com", "Fredrick", "Janson" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new DateTime(1992, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ike.angel@micway.com", "Ike", "Angel" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), new DateTime(1986, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "wyatt.kreps@micway.com", "Wyatt", "Kreps" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), new DateTime(1990, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "houston.chrysler@micway.com", "Houston", "Chrysler" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
