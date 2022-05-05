using Microsoft.EntityFrameworkCore.Migrations;

namespace DrumAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClosedHiHats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosedHiHats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrashCymbals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrashCymbals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorToms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorToms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HighToms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighToms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiHatControllers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiHatControllers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kicks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kicks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MidToms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MidToms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenHiHats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHiHats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RideCymbals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideCymbals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnareDrums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnareDrums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrumKits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ClosedHiHatId = table.Column<int>(nullable: false),
                    OpenHiHatId = table.Column<int>(nullable: false),
                    CrashCymbalId = table.Column<int>(nullable: false),
                    FloorTomId = table.Column<int>(nullable: false),
                    HighTomId = table.Column<int>(nullable: false),
                    HiHatControllerId = table.Column<int>(nullable: false),
                    KickId = table.Column<int>(nullable: false),
                    MidTomId = table.Column<int>(nullable: false),
                    RideCymbalId = table.Column<int>(nullable: false),
                    SnareDrumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrumKits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrumKits_ClosedHiHats_ClosedHiHatId",
                        column: x => x.ClosedHiHatId,
                        principalTable: "ClosedHiHats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_CrashCymbals_CrashCymbalId",
                        column: x => x.CrashCymbalId,
                        principalTable: "CrashCymbals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_FloorToms_FloorTomId",
                        column: x => x.FloorTomId,
                        principalTable: "FloorToms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_HiHatControllers_HiHatControllerId",
                        column: x => x.HiHatControllerId,
                        principalTable: "HiHatControllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_HighToms_HighTomId",
                        column: x => x.HighTomId,
                        principalTable: "HighToms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_Kicks_KickId",
                        column: x => x.KickId,
                        principalTable: "Kicks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_MidToms_MidTomId",
                        column: x => x.MidTomId,
                        principalTable: "MidToms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_OpenHiHats_OpenHiHatId",
                        column: x => x.OpenHiHatId,
                        principalTable: "OpenHiHats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_RideCymbals_RideCymbalId",
                        column: x => x.RideCymbalId,
                        principalTable: "RideCymbals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrumKits_SnareDrums_SnareDrumId",
                        column: x => x.SnareDrumId,
                        principalTable: "SnareDrums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClosedHiHats",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Closed-Hi-Hat-1" },
                    { 2, "Closed-Hi-Hat-2" },
                    { 3, "Closed-Hi-Hat-3" },
                    { 4, "Closed-Hi-Hat-4" },
                    { 5, "Closed-Hi-Hat-5" },
                    { 6, "Closed-Hi-Hat-7" },
                    { 7, "Ensoniq-SQ-1-Closed-Hi-Hat" }
                });

            migrationBuilder.InsertData(
                table: "CrashCymbals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Ensoniq-SQ-1-Crash-Cymbal" },
                    { 9, "E-Mu-Proteus-FX-Wacky-Crash-Cymbal" },
                    { 8, "Crash-Cymbal-9" },
                    { 7, "Crash-Cymbal-8" },
                    { 6, "Crash-Cymbal-7" },
                    { 5, "Crash-Cymbal-6" },
                    { 4, "Crash-Cymbal-4" },
                    { 3, "Crash-Cymbal-3" },
                    { 2, "Crash-Cymbal-2" },
                    { 1, "Crash-Cymbal-1 (1)" }
                });

            migrationBuilder.InsertData(
                table: "FloorToms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 12, "Tight-Low-Tom" },
                    { 11, "Tight-Floor-Tom" },
                    { 10, "Low-Tom-5" },
                    { 9, "Low-Tom-4" },
                    { 8, "Low-Tom-3" },
                    { 7, "Low-Tom-2" },
                    { 3, "Floor-Tom-2" },
                    { 5, "Floor-Tom-4" },
                    { 4, "Floor-Tom-3" },
                    { 2, "Ensoniq-ESQ-1-Low-Synth-Tom" },
                    { 1, "Floor-Tom-1" },
                    { 6, "Low-Tom-1" }
                });

            migrationBuilder.InsertData(
                table: "HiHatControllers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pedal-Hi-Hat-1" },
                    { 2, "Roland-R-8-Pedal-Hi-Hat" },
                    { 3, "Roland-SC-88-Pedal-Hi-Hat" },
                    { 4, "Yamaha-RM50-Pedal-Hi-Hat-1" },
                    { 5, "Yamaha-RM50-Pedal-Hi-Hat-2" }
                });

            migrationBuilder.InsertData(
                table: "HighToms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Ensoniq-ESQ-1-Hi-Synth-Tom" },
                    { 11, "Tight-High-Tom" },
                    { 10, "Hi-Tom-4" },
                    { 8, "Hi-Tom-2" },
                    { 6, "Electronic-Tom-4" },
                    { 9, "Hi-Tom-3" },
                    { 4, "Electronic-Tom-2" },
                    { 1, "Hi-Tom-1" },
                    { 2, "Electro-Tom" },
                    { 5, "Electronic-Tom-3" },
                    { 3, "Electronic-Tom-1" }
                });

            migrationBuilder.InsertData(
                table: "Kicks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 14, "Industrial-Kick-1" },
                    { 13, "Ensoniq-VFX-SD-Kick" },
                    { 12, "Ensoniq-SQ-80-Kick" },
                    { 11, "Ensoniq-SQ-1-Rock-Kick" },
                    { 10, "Electronic-Kick-3" },
                    { 8, "Electronic-Kick-1" },
                    { 9, "Electronic-Kick-2" },
                    { 6, "Dry-Kick" },
                    { 5, "Deep-Kick" },
                    { 4, "Boom-Kick" },
                    { 3, "Bass-Drum-3" },
                    { 2, "Bass-Drum-2" },
                    { 1, "Bass-Drum-1" },
                    { 7, "E-Mu-Proteus-FX-Wacky-Kick" }
                });

            migrationBuilder.InsertData(
                table: "MidToms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Tight-Mid-Tom" },
                    { 7, "Mid-Tom-6" },
                    { 6, "Mid-Tom-5" },
                    { 5, "Mid-Tom-3" },
                    { 4, "Mid-Tom-2" },
                    { 2, "Ensoniq-ESQ-1-Hi-Mid-Synth-Tom" },
                    { 1, "Mid-Tom-1" },
                    { 3, "Ensoniq-ESQ-1-Low-Mid-Synth-Tom" }
                });

            migrationBuilder.InsertData(
                table: "OpenHiHats",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open-Hi-Hat-1" },
                    { 2, "Ensoniq-SQ-1-Open-Hi-Hat" },
                    { 3, "Open-Hi-Hat-2" },
                    { 4, "Open-Hi-Hat-4" },
                    { 5, "Open-Hi-Hat-5" },
                    { 6, "Open-Hi-Hat-6" },
                    { 7, "Open-Hi-Hat-7" }
                });

            migrationBuilder.InsertData(
                table: "RideCymbals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Ensoniq-VFX-SD-Ride-Cymbal" },
                    { 1, "Ensoniq-SQ-1-Ride-Cymbal" },
                    { 2, "E-Mu-Proteus-FX-Wacky-Ride-Cymbal" }
                });

            migrationBuilder.InsertData(
                table: "SnareDrums",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Noise-Snare-1" },
                    { 1, "Ensoniq-ESQ-1-Snare" },
                    { 2, "E-Mu-Proteus-FX-Wacky-Snare" },
                    { 3, "Ensoniq-ESQ-1-Snare-2" },
                    { 4, "Ensoniq-SQ-1-Side-Stick" },
                    { 5, "Ensoniq-VFX-SD-Snare" },
                    { 6, "Hip-Hop-Snare-1" },
                    { 8, "Rim" }
                });

            migrationBuilder.InsertData(
                table: "DrumKits",
                columns: new[] { "Id", "ClosedHiHatId", "CrashCymbalId", "FloorTomId", "HiHatControllerId", "HighTomId", "KickId", "MidTomId", "Name", "OpenHiHatId", "RideCymbalId", "SnareDrumId" },
                values: new object[] { 1, 1, 1, 1, 1, 1, 1, 1, "Standard", 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_ClosedHiHatId",
                table: "DrumKits",
                column: "ClosedHiHatId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_CrashCymbalId",
                table: "DrumKits",
                column: "CrashCymbalId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_FloorTomId",
                table: "DrumKits",
                column: "FloorTomId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_HiHatControllerId",
                table: "DrumKits",
                column: "HiHatControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_HighTomId",
                table: "DrumKits",
                column: "HighTomId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_KickId",
                table: "DrumKits",
                column: "KickId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_MidTomId",
                table: "DrumKits",
                column: "MidTomId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_OpenHiHatId",
                table: "DrumKits",
                column: "OpenHiHatId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_RideCymbalId",
                table: "DrumKits",
                column: "RideCymbalId");

            migrationBuilder.CreateIndex(
                name: "IX_DrumKits_SnareDrumId",
                table: "DrumKits",
                column: "SnareDrumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrumKits");

            migrationBuilder.DropTable(
                name: "ClosedHiHats");

            migrationBuilder.DropTable(
                name: "CrashCymbals");

            migrationBuilder.DropTable(
                name: "FloorToms");

            migrationBuilder.DropTable(
                name: "HiHatControllers");

            migrationBuilder.DropTable(
                name: "HighToms");

            migrationBuilder.DropTable(
                name: "Kicks");

            migrationBuilder.DropTable(
                name: "MidToms");

            migrationBuilder.DropTable(
                name: "OpenHiHats");

            migrationBuilder.DropTable(
                name: "RideCymbals");

            migrationBuilder.DropTable(
                name: "SnareDrums");
        }
    }
}
