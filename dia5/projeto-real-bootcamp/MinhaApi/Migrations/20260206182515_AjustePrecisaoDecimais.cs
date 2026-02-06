using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class AjustePrecisaoDecimais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataProducao",
                schema: "public",
                table: "lotes_minerio",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataProducao",
                schema: "public",
                table: "lotes_minerio",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
