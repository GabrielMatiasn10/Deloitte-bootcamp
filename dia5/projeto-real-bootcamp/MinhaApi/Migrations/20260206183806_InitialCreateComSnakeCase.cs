using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateComSnakeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_lotes_minerio",
                schema: "public",
                table: "lotes_minerio");

            migrationBuilder.RenameColumn(
                name: "Umidade",
                schema: "public",
                table: "lotes_minerio",
                newName: "umidade");

            migrationBuilder.RenameColumn(
                name: "Toneladas",
                schema: "public",
                table: "lotes_minerio",
                newName: "toneladas");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "public",
                table: "lotes_minerio",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "P",
                schema: "public",
                table: "lotes_minerio",
                newName: "p");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "lotes_minerio",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TeorFe",
                schema: "public",
                table: "lotes_minerio",
                newName: "teor_fe");

            migrationBuilder.RenameColumn(
                name: "SiO2",
                schema: "public",
                table: "lotes_minerio",
                newName: "si_o2");

            migrationBuilder.RenameColumn(
                name: "MinaOrigem",
                schema: "public",
                table: "lotes_minerio",
                newName: "mina_origem");

            migrationBuilder.RenameColumn(
                name: "LocalizacaoAtual",
                schema: "public",
                table: "lotes_minerio",
                newName: "localizacao_atual");

            migrationBuilder.RenameColumn(
                name: "DataProducao",
                schema: "public",
                table: "lotes_minerio",
                newName: "data_producao");

            migrationBuilder.RenameColumn(
                name: "CodigoLote",
                schema: "public",
                table: "lotes_minerio",
                newName: "codigo_lote");

            migrationBuilder.RenameIndex(
                name: "IX_lotes_minerio_CodigoLote",
                schema: "public",
                table: "lotes_minerio",
                newName: "ix_lotes_minerio_codigo_lote");

            migrationBuilder.AddPrimaryKey(
                name: "pk_lotes_minerio",
                schema: "public",
                table: "lotes_minerio",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_lotes_minerio",
                schema: "public",
                table: "lotes_minerio");

            migrationBuilder.RenameColumn(
                name: "umidade",
                schema: "public",
                table: "lotes_minerio",
                newName: "Umidade");

            migrationBuilder.RenameColumn(
                name: "toneladas",
                schema: "public",
                table: "lotes_minerio",
                newName: "Toneladas");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "public",
                table: "lotes_minerio",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "p",
                schema: "public",
                table: "lotes_minerio",
                newName: "P");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "lotes_minerio",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "teor_fe",
                schema: "public",
                table: "lotes_minerio",
                newName: "TeorFe");

            migrationBuilder.RenameColumn(
                name: "si_o2",
                schema: "public",
                table: "lotes_minerio",
                newName: "SiO2");

            migrationBuilder.RenameColumn(
                name: "mina_origem",
                schema: "public",
                table: "lotes_minerio",
                newName: "MinaOrigem");

            migrationBuilder.RenameColumn(
                name: "localizacao_atual",
                schema: "public",
                table: "lotes_minerio",
                newName: "LocalizacaoAtual");

            migrationBuilder.RenameColumn(
                name: "data_producao",
                schema: "public",
                table: "lotes_minerio",
                newName: "DataProducao");

            migrationBuilder.RenameColumn(
                name: "codigo_lote",
                schema: "public",
                table: "lotes_minerio",
                newName: "CodigoLote");

            migrationBuilder.RenameIndex(
                name: "ix_lotes_minerio_codigo_lote",
                schema: "public",
                table: "lotes_minerio",
                newName: "IX_lotes_minerio_CodigoLote");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lotes_minerio",
                schema: "public",
                table: "lotes_minerio",
                column: "Id");
        }
    }
}
