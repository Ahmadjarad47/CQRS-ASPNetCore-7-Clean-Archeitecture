using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description one", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Category One" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description tow", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Category tow" },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description three", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Category three" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desciption one", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "product one", 150m },
                    { 2, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desciption two", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "product two", 300m },
                    { 3, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desciption three", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "product three", 900m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
