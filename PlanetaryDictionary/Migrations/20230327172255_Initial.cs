using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetaryDictionary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FunFact = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Climate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LifeFormDetails = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.PlanetId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "PlanetId", "Climate", "FunFact", "LifeFormDetails", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "The surface is both extremely hot and cold, with temperatures ranging from 800F to -290F.", "This planet is shrinking! Mercury has no moons, and has volcanic activity.", "Steves, crablike humanoids, 3 inches tall, 5 claws and no head, eyes on feet", "Mercury", 36000000 },
                    { 2, "Is around 900F. Even spacecraft cannot withstand the atmosphere for long.", "Venus has no moons. A block of lead on Venus will melt like a block of ice would on Earth.", "Zorthraxians, gelatinous cubes, 4 legs, 6 feet in size, 12 hearts, very angry all the time", "Venus", 12 },
                    { 3, "Mars's atmosphere is primarily formed of carbon dioxide. Temperatures range from -220F to 70F, with an average temperature of -81F. Mars has seasons that cause its frozen water and carbon dioxide caps to shrink and grow.", "Mars has two moons. Mars has frozen water and is seismically active. It has the hightest mountain in our solar system.", "Blarbs, Candy bars with delicious nougat centers, on one 20 foot wheel with spinner rims", "Mars", 10000 },
                    { 4, "Extremely windy with averages temperatures hovering around -285F.", "Saturn could float in water due to it's gaseous nature. It has 82 moons.", "Recklins, flying recliner-chair like creatures, roughly the size of blue-whales", "Saturn", 5000000 },
                    { 5, "Average temperature is -387F, thin atmosphere made of nitrogen, methane and carbone monoxide", "It is a dwarf planet, it's half the size of the US.", "Plutonians, holograms, exact replicas of Pluto from Disney, loves holograms of earth pizza", "Pluto", 9999999 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
