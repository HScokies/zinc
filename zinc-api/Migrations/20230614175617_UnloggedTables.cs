using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zinc_api.Migrations
{
    /// <inheritdoc />
    public partial class UnloggedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "vysh")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "velc_kvp6")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "velc_kvp5")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "skc2")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "skc1")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "obg2")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "obg1")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "kec2")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "kec1")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "kec_kadmievoe")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "hvp")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "gmc_velc2")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "gmc_velc1")
                .Annotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "gmc_larox")
                .Annotation("Npgsql:UnloggedTable", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "vysh")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "velc_kvp6")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "velc_kvp5")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "skc2")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "skc1")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "obg2")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "obg1")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "kec2")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "kec1")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "kec_kadmievoe")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "hvp")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "gmc_velc2")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "gmc_velc1")
                .OldAnnotation("Npgsql:UnloggedTable", true);

            migrationBuilder.AlterTable(
                name: "gmc_larox")
                .OldAnnotation("Npgsql:UnloggedTable", true);
        }
    }
}
