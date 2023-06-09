using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zinc_api.Migrations
{
    /// <inheritdoc />
    public partial class MigInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gmc_larox",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gmc_larox", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gmc_velc1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gmc_velc1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gmc_velc2",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gmc_velc2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hvp",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hvp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kec_kadmievoe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kec_kadmievoe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kec1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kec1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kec2",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kec2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "obg1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obg1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "obg2",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obg2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skc1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skc1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skc2",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skc2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "velc_kvp5",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_velc_kvp5", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "velc_kvp6",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_velc_kvp6", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vysh",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<short>(type: "smallint", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    val = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vysh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "station",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    departmentid = table.Column<int>(type: "integer", nullable: false),
                    name_table = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_station", x => x.id);
                    table.ForeignKey(
                        name: "FK_station_department_departmentid",
                        column: x => x.departmentid,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tech_pok",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num = table.Column<int>(type: "integer", nullable: false),
                    dep_id = table.Column<int>(type: "integer", nullable: false),
                    departmentid = table.Column<int>(type: "integer", nullable: false),
                    station_id = table.Column<int>(type: "integer", nullable: false),
                    stationid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    uom = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tech_pok", x => x.id);
                    table.ForeignKey(
                        name: "FK_tech_pok_department_departmentid",
                        column: x => x.departmentid,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tech_pok_station_stationid",
                        column: x => x.stationid,
                        principalTable: "station",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "OBG" },
                    { 2, "VELC" },
                    { 3, "GMC" },
                    { 4, "SKC" },
                    { 5, "HVP" },
                    { 6, "VYSH" },
                    { 7, "KEC" }
                });

            migrationBuilder.InsertData(
                table: "station",
                columns: new[] { "id", "departmentid", "name", "name_table" },
                values: new object[,]
                {
                    { 1, 1, "IUS_OBG511", "OBG1" },
                    { 2, 1, "IUS_OBG52", "OBG2" },
                    { 3, 2, "IUS_VELC1", "GMC_Velc1" },
                    { 4, 2, "IUS_VELC2", "GMC_Velc2" },
                    { 5, 2, "VELC5PC21", "Velc_KVP5" },
                    { 6, 2, "KVP61", "Velc_KVP6" },
                    { 7, 3, "IUS_VELC1", "GMC_Velc1" },
                    { 8, 3, "IUS_VELC2", "GMC_Velc2" },
                    { 9, 3, "LAROX", "GMC_Larox" },
                    { 10, 4, "IUS_SKC42", "SKC1" },
                    { 11, 4, "IUS_SKC43", "SKC2" },
                    { 12, 5, "HVP_station", "HVP" },
                    { 13, 6, "IUS_V5", "Vysh" },
                    { 14, 7, "CHPEW2", "KEC1" },
                    { 15, 7, "CHPEW3", "KEC2" },
                    { 16, 7, "KADMIEVOE", "KEC_Kadmievoe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_station_departmentid",
                table: "station",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_tech_pok_departmentid",
                table: "tech_pok",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_tech_pok_stationid",
                table: "tech_pok",
                column: "stationid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gmc_larox");

            migrationBuilder.DropTable(
                name: "gmc_velc1");

            migrationBuilder.DropTable(
                name: "gmc_velc2");

            migrationBuilder.DropTable(
                name: "hvp");

            migrationBuilder.DropTable(
                name: "kec_kadmievoe");

            migrationBuilder.DropTable(
                name: "kec1");

            migrationBuilder.DropTable(
                name: "kec2");

            migrationBuilder.DropTable(
                name: "obg1");

            migrationBuilder.DropTable(
                name: "obg2");

            migrationBuilder.DropTable(
                name: "skc1");

            migrationBuilder.DropTable(
                name: "skc2");

            migrationBuilder.DropTable(
                name: "tech_pok");

            migrationBuilder.DropTable(
                name: "velc_kvp5");

            migrationBuilder.DropTable(
                name: "velc_kvp6");

            migrationBuilder.DropTable(
                name: "vysh");

            migrationBuilder.DropTable(
                name: "station");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
