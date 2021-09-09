using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaDeInstrumentosAPI.Migrations
{
    public partial class codelabaula12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Instrument",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createdById",
                table: "Instrument",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated",
                table: "Instrument",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedById",
                table: "Instrument",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_createdById",
                table: "Instrument",
                column: "createdById");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_updatedById",
                table: "Instrument",
                column: "updatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_AspNetUsers_createdById",
                table: "Instrument",
                column: "createdById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_AspNetUsers_updatedById",
                table: "Instrument",
                column: "updatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_AspNetUsers_createdById",
                table: "Instrument");

            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_AspNetUsers_updatedById",
                table: "Instrument");

            migrationBuilder.DropIndex(
                name: "IX_Instrument_createdById",
                table: "Instrument");

            migrationBuilder.DropIndex(
                name: "IX_Instrument_updatedById",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "createdById",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "updated",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "updatedById",
                table: "Instrument");
        }
    }
}
