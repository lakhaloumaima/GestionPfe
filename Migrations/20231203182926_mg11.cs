using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pfeapp2.Migrations
{
    /// <inheritdoc />
    public partial class mg11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateN = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Societe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lib = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pfe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadrantID = table.Column<int>(type: "int", nullable: false),
                    SocieteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pfe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pfe_Enseignant_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pfe_Societe_SocieteID",
                        column: x => x.SocieteID,
                        principalTable: "Societe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pfe_etudiant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PfeId = table.Column<int>(type: "int", nullable: false),
                    EtudiantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pfe_etudiant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pfe_etudiant_Etudiant_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "Etudiant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pfe_etudiant_Pfe_PfeId",
                        column: x => x.PfeId,
                        principalTable: "Pfe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soutenance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Heure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PfeId = table.Column<int>(type: "int", nullable: false),
                    PresidentId = table.Column<int>(type: "int", nullable: false),
                    RapporteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soutenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soutenance_Enseignant_PresidentId",
                        column: x => x.PresidentId,
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soutenance_Enseignant_RapporteurId",
                        column: x => x.RapporteurId,
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soutenance_Pfe_PfeId",
                        column: x => x.PfeId,
                        principalTable: "Pfe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_EncadrantID",
                table: "Pfe",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_SocieteID",
                table: "Pfe",
                column: "SocieteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_etudiant_EtudiantID",
                table: "Pfe_etudiant",
                column: "EtudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_etudiant_PfeId",
                table: "Pfe_etudiant",
                column: "PfeId");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_PfeId",
                table: "Soutenance",
                column: "PfeId");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_PresidentId",
                table: "Soutenance",
                column: "PresidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_RapporteurId",
                table: "Soutenance",
                column: "RapporteurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pfe_etudiant");

            migrationBuilder.DropTable(
                name: "Soutenance");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Pfe");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Societe");
        }
    }
}
