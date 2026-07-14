using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DSPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISRC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackDistributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DspId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackDistributions_DSPs_DspId",
                        column: x => x.DspId,
                        principalTable: "DSPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackDistributions_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Country", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-1111-1111-1111-111111111111"), "Tunis", "tamer@test.com", "Tamer Nour" },
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Egypt", "ahmed@test.com", "Ahmed Ali" },
                    { new Guid("20000000-1111-1111-1111-111111111111"), "Saudia", "mona@test.com", "Mona Yasser" }
                });

            migrationBuilder.InsertData(
                table: "DSPs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-2222-2222-222222222222"), "Spotify" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Youtube" },
                    { new Guid("33333333-2222-2222-2222-222222222222"), "TickTock" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "ArtistId", "Genre", "ISRC", "ReleaseDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("11112211-4444-4444-4444-444444444444"), new Guid("10000000-1111-1111-1111-111111111111"), "Pop", "US-AAA-93-00008", new DateOnly(2018, 1, 1), 2, "Track 8" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), "Pop", "US-AAA-23-00001", new DateOnly(2023, 1, 1), 3, "Track 1" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("10000000-1111-1111-1111-111111111111"), "Pop", "US-AAA-93-00002", new DateOnly(2024, 1, 1), 2, "Track 2" },
                    { new Guid("55555555-3333-3333-3333-333333333333"), new Guid("20000000-1111-1111-1111-111111111111"), "Pop", "US-AAA-23-00003", new DateOnly(2020, 1, 1), 3, "Track 3" },
                    { new Guid("66666666-4444-4444-4444-444444444444"), new Guid("10000000-1111-1111-1111-111111111111"), "Pop", "US-AAA-93-00004", new DateOnly(2021, 1, 1), 2, "Track 4" },
                    { new Guid("77777777-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), "Pop", "US-AAA-23-00005", new DateOnly(2025, 1, 1), 3, "Track 5" },
                    { new Guid("88888888-4444-4444-4444-444444444444"), new Guid("10000000-1111-1111-1111-111111111111"), "Pop", "US-AAA-93-00006", new DateOnly(2026, 1, 1), 2, "Track 6" },
                    { new Guid("99999999-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), "Pop", "US-AAA-23-00007", new DateOnly(2019, 1, 1), 3, "Track 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackDistributions_DspId",
                table: "TrackDistributions",
                column: "DspId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackDistributions_TrackId",
                table: "TrackDistributions",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ArtistId",
                table: "Tracks",
                column: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackDistributions");

            migrationBuilder.DropTable(
                name: "DSPs");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
