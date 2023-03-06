using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jacaranda.Migrations
{
    /// <inheritdoc />
    public partial class FixMailVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "mail_verification");

            migrationBuilder.DropColumn(
                name: "role",
                table: "mail_verification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "activated_at",
                table: "mail_verification",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "mail_verification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_mail_verification_user_id",
                table: "mail_verification",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mail_verification_user_user_id",
                table: "mail_verification",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mail_verification_user_user_id",
                table: "mail_verification");

            migrationBuilder.DropIndex(
                name: "ix_mail_verification_user_id",
                table: "mail_verification");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "mail_verification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "activated_at",
                table: "mail_verification",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "mail_verification",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "mail_verification",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
