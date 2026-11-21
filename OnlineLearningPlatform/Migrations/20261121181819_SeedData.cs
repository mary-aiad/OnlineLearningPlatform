using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Programming courses", "Programming", null },
                    { 4, "Database courses", "Database", null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DateJoined", "Email", "FullName", "ShortBio" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@test.com", "Ahmed Mohamed", "Backend Developer" },
                    { 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@test.com", "Sara Ali", "Database Specialist" },
                    { 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@test.com", "Omar Hassan", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Backend development", "Backend", 1 },
                    { 5, "SQL Server courses", "SQL Server", 4 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryID", "Description", "InstructorID", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Learn C# basics", 1, true, 1, 500m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals" },
                    { 2, 1, "Object oriented programming", 1, true, 2, 700m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OOP with C#" },
                    { 3, 1, "Build web applications", 1, true, 3, 1000m, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core" },
                    { 4, 1, "Learn SQL", 1, true, 1, 400m, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Fundamentals" },
                    { 5, 1, "Advanced database concepts", 1, false, 3, 800m, null, "Advanced SQL" },
                    { 6, 1, "Learn EF Core", 1, false, 2, 900m, null, "Entity Framework Core" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 3, "ASP.NET development", "ASP.NET", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
