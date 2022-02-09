using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEventos.Persistence.Migrations
{
    public partial class EventoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoPalestrante_Palestrante_PalestrantesId",
                table: "EventoPalestrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Lote_Eventos_EventoId",
                table: "Lote");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSocial_Eventos_EventoId",
                table: "RedeSocial");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSocial_Palestrante_PalestranteId",
                table: "RedeSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedeSocial",
                table: "RedeSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Palestrante",
                table: "Palestrante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lote",
                table: "Lote");

            migrationBuilder.RenameTable(
                name: "RedeSocial",
                newName: "RedesSociais");

            migrationBuilder.RenameTable(
                name: "Palestrante",
                newName: "Palestrantes");

            migrationBuilder.RenameTable(
                name: "Lote",
                newName: "Lotes");

            migrationBuilder.RenameIndex(
                name: "IX_RedeSocial_PalestranteId",
                table: "RedesSociais",
                newName: "IX_RedesSociais_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedeSocial_EventoId",
                table: "RedesSociais",
                newName: "IX_RedesSociais_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lote_EventoId",
                table: "Lotes",
                newName: "IX_Lotes_EventoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedesSociais",
                table: "RedesSociais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palestrantes",
                table: "Palestrantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lotes",
                table: "Lotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventoPalestrante_Palestrantes_PalestrantesId",
                table: "EventoPalestrante",
                column: "PalestrantesId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Eventos_EventoId",
                table: "Lotes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSociais_Eventos_EventoId",
                table: "RedesSociais",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSociais_Palestrantes_PalestranteId",
                table: "RedesSociais",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoPalestrante_Palestrantes_PalestrantesId",
                table: "EventoPalestrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Eventos_EventoId",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSociais_Eventos_EventoId",
                table: "RedesSociais");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSociais_Palestrantes_PalestranteId",
                table: "RedesSociais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedesSociais",
                table: "RedesSociais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Palestrantes",
                table: "Palestrantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lotes",
                table: "Lotes");

            migrationBuilder.RenameTable(
                name: "RedesSociais",
                newName: "RedeSocial");

            migrationBuilder.RenameTable(
                name: "Palestrantes",
                newName: "Palestrante");

            migrationBuilder.RenameTable(
                name: "Lotes",
                newName: "Lote");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSociais_PalestranteId",
                table: "RedeSocial",
                newName: "IX_RedeSocial_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSociais_EventoId",
                table: "RedeSocial",
                newName: "IX_RedeSocial_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lotes_EventoId",
                table: "Lote",
                newName: "IX_Lote_EventoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedeSocial",
                table: "RedeSocial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palestrante",
                table: "Palestrante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lote",
                table: "Lote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventoPalestrante_Palestrante_PalestrantesId",
                table: "EventoPalestrante",
                column: "PalestrantesId",
                principalTable: "Palestrante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lote_Eventos_EventoId",
                table: "Lote",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSocial_Eventos_EventoId",
                table: "RedeSocial",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSocial_Palestrante_PalestranteId",
                table: "RedeSocial",
                column: "PalestranteId",
                principalTable: "Palestrante",
                principalColumn: "Id");
        }
    }
}
