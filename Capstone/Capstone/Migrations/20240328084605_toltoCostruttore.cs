using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    /// <inheritdoc />
    public partial class toltoCostruttore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Azienda",
                columns: table => new
                {
                    IdAzienda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Città = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitudine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitudine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Immagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Azienda", x => x.IdAzienda);
                });

            migrationBuilder.CreateTable(
                name: "Giorni",
                columns: table => new
                {
                    IdGiorno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiornoCorrente = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giorni", x => x.IdGiorno);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cellulare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Città = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitudine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitudine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isOnline = table.Column<bool>(type: "bit", nullable: false),
                    Immagine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Servizi",
                columns: table => new
                {
                    IdServizio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Immagine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAzienda_Fk = table.Column<int>(type: "int", nullable: false),
                    AziendaIdAzienda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servizi", x => x.IdServizio);
                    table.ForeignKey(
                        name: "FK_Servizi_Azienda_AziendaIdAzienda",
                        column: x => x.AziendaIdAzienda,
                        principalTable: "Azienda",
                        principalColumn: "IdAzienda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recensioni",
                columns: table => new
                {
                    IdRecensione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Testo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voto = table.Column<int>(type: "int", nullable: false),
                    IdUser_Fk = table.Column<int>(type: "int", nullable: false),
                    IdAzienda_Fk = table.Column<int>(type: "int", nullable: false),
                    UserIdUser = table.Column<int>(type: "int", nullable: false),
                    AziendaIdAzienda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recensioni", x => x.IdRecensione);
                    table.ForeignKey(
                        name: "FK_Recensioni_Azienda_AziendaIdAzienda",
                        column: x => x.AziendaIdAzienda,
                        principalTable: "Azienda",
                        principalColumn: "IdAzienda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recensioni_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelezioneServizi",
                columns: table => new
                {
                    IdSelezioneServizio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoServizio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ora = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdUser_Fk = table.Column<int>(type: "int", nullable: false),
                    IdServizio_Fk = table.Column<int>(type: "int", nullable: false),
                    UserIdUser = table.Column<int>(type: "int", nullable: false),
                    ServiziIdServizio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelezioneServizi", x => x.IdSelezioneServizio);
                    table.ForeignKey(
                        name: "FK_SelezioneServizi_Servizi_ServiziIdServizio",
                        column: x => x.ServiziIdServizio,
                        principalTable: "Servizi",
                        principalColumn: "IdServizio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelezioneServizi_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    IdSlot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fasciaOraria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numPrenotazioni = table.Column<int>(type: "int", nullable: false),
                    IdServizio_Fk = table.Column<int>(type: "int", nullable: false),
                    Giorno_FK = table.Column<int>(type: "int", nullable: false),
                    ServiziIdServizio = table.Column<int>(type: "int", nullable: false),
                    GiornoCorrenteIdGiorno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.IdSlot);
                    table.ForeignKey(
                        name: "FK_Slot_Giorni_GiornoCorrenteIdGiorno",
                        column: x => x.GiornoCorrenteIdGiorno,
                        principalTable: "Giorni",
                        principalColumn: "IdGiorno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_Servizi_ServiziIdServizio",
                        column: x => x.ServiziIdServizio,
                        principalTable: "Servizi",
                        principalColumn: "IdServizio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recensioni_AziendaIdAzienda",
                table: "Recensioni",
                column: "AziendaIdAzienda");

            migrationBuilder.CreateIndex(
                name: "IX_Recensioni_UserIdUser",
                table: "Recensioni",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SelezioneServizi_ServiziIdServizio",
                table: "SelezioneServizi",
                column: "ServiziIdServizio");

            migrationBuilder.CreateIndex(
                name: "IX_SelezioneServizi_UserIdUser",
                table: "SelezioneServizi",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Servizi_AziendaIdAzienda",
                table: "Servizi",
                column: "AziendaIdAzienda");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_GiornoCorrenteIdGiorno",
                table: "Slot",
                column: "GiornoCorrenteIdGiorno");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_ServiziIdServizio",
                table: "Slot",
                column: "ServiziIdServizio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recensioni");

            migrationBuilder.DropTable(
                name: "SelezioneServizi");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Giorni");

            migrationBuilder.DropTable(
                name: "Servizi");

            migrationBuilder.DropTable(
                name: "Azienda");
        }
    }
}
