using Microsoft.EntityFrameworkCore.Migrations;
using Vega.Models;

namespace Vega.Migrations
{
    public partial class FillInMakesAndFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Makes ON");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (1, 'Audi')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (2, 'BMW')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (3, 'Ford')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (4, 'Mercedes')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (5, 'Opel')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (6, 'Porsche')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (7, 'Volkswagen')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (8, 'Honda')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (9, 'Mazda')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (10, 'Nissan')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (11, 'Chrysler')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (12, 'Dodge')");
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Makes OFF");

            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Features ON");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Features] ({nameof(Feature.Id)}, {nameof(Feature.Name)}) VALUES (1, 'REVERSE SENSING SYSTEM')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Features] ({nameof(Feature.Id)}, {nameof(Feature.Name)}) VALUES (2, 'AIRBAGS')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Features] ({nameof(Feature.Id)}, {nameof(Feature.Name)}) VALUES (3, 'ADJUSTABLE COMFORTS')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Features] ({nameof(Feature.Id)}, {nameof(Feature.Name)}) VALUES (4, 'DEFOGGER')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Features] ({nameof(Feature.Id)}, {nameof(Feature.Name)}) VALUES (5, 'ANTILOCK BRAKING SYSTEM')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Features] ({nameof(Feature.Id)}, {nameof(Feature.Name)}) VALUES (6, 'MULTIPLE 12V POWER OUTLETS')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Features] ({nameof(Feature.Id)}, {nameof(Feature.Name)}) VALUES (7, 'TRACTION CONTROL')");
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Features OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM dbo.Makes");
            migrationBuilder.Sql("DELETE FROM dbo.Features");
        }
    }
}
