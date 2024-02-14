using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TetePizza.Data.Migrations
{
    /// <inheritdoc />
    public partial class PizzaIngredientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Pizzas_PizzaId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_PizzaId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Ingredientes");

            migrationBuilder.CreateTable(
                name: "PizzaIngrediente",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    IngredienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngrediente", x => new { x.PizzaId, x.IngredienteId });
                    table.ForeignKey(
                        name: "FK_PizzaIngrediente_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngrediente_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "Id", "Description", "IsVegan", "Name", "Origin", "Stock" },
                values: new object[,]
                {
                    { 1, "Descripción de la cebolla", true, "Cebolla", "Vegetable", 100 },
                    { 2, "Descripción del pepeorino", false, "Pepeorino", "Animal", 100 }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "IsGlutenFree", "Name" },
                values: new object[,]
                {
                    { 1, true, "Hawaiana" },
                    { 2, true, "Barbacoa" }
                });

            migrationBuilder.InsertData(
                table: "PizzaIngrediente",
                columns: new[] { "IngredienteId", "PizzaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngrediente_IngredienteId",
                table: "PizzaIngrediente",
                column: "IngredienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaIngrediente");

            migrationBuilder.DeleteData(
                table: "Ingredientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Ingredientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PizzaId",
                table: "Ingredientes",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Pizzas_PizzaId",
                table: "Ingredientes",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
