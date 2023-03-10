using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace C1CopyMudBlazor.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    Cabinet = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offices_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkPlaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeID = table.Column<int>(type: "int", nullable: false),
                    WorkplaceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlaces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkPlaces_Offices_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Offices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeID = table.Column<int>(type: "int", nullable: true),
                    WorkPlaceID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    ServerIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnyDesk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnyDeskPass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FIOEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneLog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhonePass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneOutsideNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FIO = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Workers_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Offices_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Offices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Workers_WorkPlaces_WorkPlaceID",
                        column: x => x.WorkPlaceID,
                        principalTable: "WorkPlaces",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LegalEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    BuhID = table.Column<int>(type: "int", nullable: true),
                    DirID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UNP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LegalEntities_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalEntities_Workers_BuhID",
                        column: x => x.BuhID,
                        principalTable: "Workers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LegalEntities_Workers_DirID",
                        column: x => x.DirID,
                        principalTable: "Workers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Teches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeID = table.Column<int>(type: "int", nullable: true),
                    WorkerID = table.Column<int>(type: "int", nullable: true),
                    WorkPlaceID = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventaryID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teches_Offices_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Offices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Teches_WorkPlaces_WorkPlaceID",
                        column: x => x.WorkPlaceID,
                        principalTable: "WorkPlaces",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Teches_Workers_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "Workers",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "Email", "Password", "RoleID" },
                values: new object[,]
                {
                    { 1, "asd", "123", 2 },
                    { 2, "theanfishow@gmail.com", "123", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleID",
                table: "Accounts",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntities_BuhID",
                table: "LegalEntities",
                column: "BuhID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntities_ClientID",
                table: "LegalEntities",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntities_DirID",
                table: "LegalEntities",
                column: "DirID");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_ClientID",
                table: "Offices",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Teches_OfficeID",
                table: "Teches",
                column: "OfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_Teches_WorkerID",
                table: "Teches",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teches_WorkPlaceID",
                table: "Teches",
                column: "WorkPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ClientID",
                table: "Workers",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_OfficeID",
                table: "Workers",
                column: "OfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkPlaceID",
                table: "Workers",
                column: "WorkPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_OfficeID",
                table: "WorkPlaces",
                column: "OfficeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "LegalEntities");

            migrationBuilder.DropTable(
                name: "Teches");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "WorkPlaces");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
