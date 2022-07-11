using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ums_dotnet.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authority", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authority_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "johnny@depp.com", "Johnny", "Depp", "johnny123", "Active", "John1" },
                    { 2, "jimm@carrey.com", "Jimm", "Carrey", "Jimm123", "Active", "Jimm1" },
                    { 3, "angelina@jolie.com", "Angelina", "Jolie", "angelina123", "Active", "Angelina1" },
                    { 4, "dwayne@johnson.com", "Dwayne", "Johnson", "dwayne123", "Active", "Dwayne1" },
                    { 5, "tom@hanks.com", "Tom", "Hanks", "tom123", "Active", "Tom1" },
                    { 6, "tom@cruise.com", "Tom", "Cruise", "tom123", "Active", "Tom1" },
                    { 7, "monica@belucci.com", "Monica", "Belucci", "belucci123", "Inactive", "Monica1" },
                    { 8, "anthony@hopkins.com", "Anthony", "Hopkins", "anthony123", "Inactive", "Anthony1" },
                    { 9, "jack@nicholson.com", "Jack", "Nicholson", "jack123", "Inactive", "Jack1" },
                    { 10, "al@pacino.com", "Al", "Pacino", "al123", "Active", "Al1" },
                    { 11, "dustin@hoffman.com", "Dustin", "Hoffman", "dustin123", "Active", "Dustin1" },
                    { 12, "danzel@washington.com", "Denzel", "Washington", "danzel123", "Active", "Danzel1" },
                    { 13, "robin@williams.com", "Robin", "Williams", "robin123", "Active", "Robin1" },
                    { 14, "morgan@freeman.com", "Morgan", "Freeman", "morgan123", "Active", "Morgan1" },
                    { 15, "gene@hackman.com", "Gene", "Hackman", "gene123", "Inactive", "Gene1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authority_UserId",
                table: "Authority",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authority");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
