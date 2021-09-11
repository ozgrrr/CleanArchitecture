using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CleanArchitecture.Persistence.Migrations
{
    public partial class InitialWithDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'12', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Active", "Created", "Deleted", "Email", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 9, 11, 21, 10, 54, 471, DateTimeKind.Local).AddTicks(6122), false, "Sincere@april.biz", "Leanne Graham", "534547", "Bret" },
                    { 2, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(5421), false, "Shanna@melissa.tv", "Ervin Howell", "521333", "Antonette" },
                    { 3, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(5730), false, "Nathan@yesenia.net", "Clementine Bauch", "433774", "Samantha" },
                    { 4, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(5781), false, "Julianne.OConner@kory.org", "Patricia Lebsack", "577615", "Karianne" },
                    { 5, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(5825), false, "Lucio_Hettinger@annie.ca", "Chelsey Dietrich", "671265", "Kamren" },
                    { 6, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(5878), false, "Karley_Dach@jasper.info", "Mrs. Dennis Schulist", "662143", "Leopoldo_Corkery" },
                    { 7, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(5926), false, "Telly.Hoeger@billy.biz", "Kurtis Weissnat", "819913", "Elwyn.Skiles" },
                    { 8, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(5969), false, "Sherwood@rosamond.me", "Nicholas Runolfsdottir V", "851146", "Maxime_Nienow" },
                    { 9, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(6012), false, "Chaim_McDermott@dana.io", "Glenna Reichert", "609162", "Delphine" },
                    { 10, true, new DateTime(2021, 9, 11, 21, 10, 54, 474, DateTimeKind.Local).AddTicks(6141), false, "Rey.Padberg@karina.biz", "Clementina DuBuque", "454915", "Moriah.Stanton" },
                    { 11, true, new DateTime(2021, 9, 11, 21, 10, 54, 475, DateTimeKind.Local).AddTicks(3737), false, "ozgrrr@mail.com", "Default User", "123123123", "ozgrrr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Username_Email_Active_Deleted",
                table: "Persons",
                columns: new[] { "Username", "Email", "Active", "Deleted" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
