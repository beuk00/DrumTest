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
                name: "HiHatsControllers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiHatsControllers", x => x.Id);
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
                        name: "FK_DrumKits_HiHatsControllers_HiHatControllerId",
                        column: x => x.HiHatControllerId,
                        principalTable: "HiHatsControllers",
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
                values: new object[] { 1, "Closed-Hi-Hat-1" });

            migrationBuilder.InsertData(
                table: "CrashCymbals",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Crash-Cymbal-1 (1)" });

            migrationBuilder.InsertData(
                table: "FloorToms",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Floor-Tom-1" });

            migrationBuilder.InsertData(
                table: "HiHatsControllers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Pedal-Hi-Hat-1" });

            migrationBuilder.InsertData(
                table: "HighToms",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Hi-Tom-1" });

            migrationBuilder.InsertData(
                table: "Kicks",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Bass-Drum-1" });

            migrationBuilder.InsertData(
                table: "MidToms",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mid-Tom-1" });

            migrationBuilder.InsertData(
                table: "OpenHiHats",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open-Hi-Hat-1" });

            migrationBuilder.InsertData(
                table: "RideCymbals",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Ensoniq-SQ-1-Ride-Cymbal" });

            migrationBuilder.InsertData(
                table: "SnareDrums",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Ensoniq-ESQ-1-Snare" });

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
                name: "HiHatsControllers");

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
