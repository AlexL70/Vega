using Microsoft.EntityFrameworkCore.Migrations;
using Vega.Core.Models;

namespace Vega.Migrations
{
    public partial class FillInMakesAndFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Makes ON");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (1, 'Audi')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('A1', 1)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('A3', 1)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('A5', 1)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('A6', 1)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('A7', 1)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('A8', 1)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (2, 'BMW')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('M3', 2)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('X3', 2)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Z4', 2)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (3, 'Ford')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('C-Max', 3)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('EcoSport', 3)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Edge', 3)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Escape', 3)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Expedition', 3)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Expedition MAX', 3)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Explorer', 3)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (4, 'Mercedes')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('A-Class', 4)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('AMG-GT', 4)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('C-Class', 4)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('CLA-Class', 4)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('CLS-Class', 4)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('E-Class', 4)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('G-Class', 4)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (5, 'Opel')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Corsa', 5)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Insignia', 5)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Grandland X', 5)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (6, 'Porsche')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('911', 6)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('930', 6)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('944', 6)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Cayenne', 6)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (7, 'Volkswagen')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Ameo', 7)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Beetle', 7)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Bora', 7)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Golf', 7)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Jetta', 7)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (8, 'Honda')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Amaze', 8)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('City', 8)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Civic', 8)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Jazz', 8)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('WRV', 8)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('', 8)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (9, 'Mazda')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('MX-5', 9)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('3', 9)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('RX-8', 9)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (10, 'Nissan')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('370Z', 10)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Altima', 10)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Armada', 10)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Frontier', 10)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('GT-R', 10)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Kicks', 10)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('LEAF', 10)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Maxima', 10)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (11, 'Chrysler')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('300', 11)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('PT Cruiser', 11)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Crossfire', 11)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Voyager', 11)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Makes] ( {nameof(Make.Id)}, {nameof(Make.Name)}) VALUES (12, 'Dodge')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Challenger', 12)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Charger', 12)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Durango', 12)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Grand Caravan', 12)");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Models] ([Name] ,[MakeId]) VALUES ('Journey', 12)");
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
            migrationBuilder.Sql("DELETE FROM dbo.Models");
            migrationBuilder.Sql("DELETE FROM dbo.Makes");
            migrationBuilder.Sql("DELETE FROM dbo.Features");
        }
    }
}
