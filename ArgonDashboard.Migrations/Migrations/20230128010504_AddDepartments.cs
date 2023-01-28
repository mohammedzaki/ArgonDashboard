using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgonDashboard.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    isldap = table.Column<bool>(name: "is_ldap", type: "INTEGER", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "INTEGER", nullable: false),
                    createdby = table.Column<long>(name: "created_by", type: "INTEGER", nullable: true),
                    updatedby = table.Column<long>(name: "updated_by", type: "INTEGER", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "department_name_unique",
                table: "departments",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
