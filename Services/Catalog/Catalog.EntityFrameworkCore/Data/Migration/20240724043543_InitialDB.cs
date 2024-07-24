#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.EntityFrameworkCore.Data.Migration;

/// <inheritdoc />
public partial class InitialDB : Microsoft.EntityFrameworkCore.Migrations.Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Products",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                Category = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                ImageFile = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                Price = table.Column<decimal>("decimal(18,2)", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: true),
                CreatedBy = table.Column<Guid>("uniqueidentifier", nullable: false),
                LastModified = table.Column<DateTime>("datetime2", nullable: true),
                LastModifiedBy = table.Column<Guid>("uniqueidentifier", nullable: false),
                IsActive = table.Column<bool>("bit", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Products", x => x.Id); });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Products");
    }
}