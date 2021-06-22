using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MQTT_DataLogger.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUUsage = table.Column<double>(type: "float", nullable: false),
                    CPUTemp = table.Column<double>(type: "float", nullable: false),
                    GPUUsage = table.Column<double>(type: "float", nullable: false),
                    GPUTemp = table.Column<double>(type: "float", nullable: false),
                    RAMUsage = table.Column<double>(type: "float", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
