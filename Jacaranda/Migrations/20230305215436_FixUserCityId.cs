using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jacaranda.Migrations
{
    /// <inheritdoc />
    public partial class FixUserCityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_city_city_id",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "user",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "city_id",
                table: "user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "code",
                table: "partner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_user_city_city_id",
                table: "user",
                column: "city_id",
                principalTable: "city",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_city_city_id",
                table: "user");

            migrationBuilder.DropColumn(
                name: "code",
                table: "partner");

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "user",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "city_id",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_user_city_city_id",
                table: "user",
                column: "city_id",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
