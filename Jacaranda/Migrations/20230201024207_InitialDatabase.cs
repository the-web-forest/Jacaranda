using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Jacaranda.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "administrator",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_administrator", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "biome",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_biome", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "certificate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    certificateid = table.Column<string>(name: "certificate_id", type: "varchar(13)", maxLength: 13, nullable: false),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    file = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificate", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mail_verification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    role = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    token = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    activatedat = table.Column<DateTime>(name: "activated_at", type: "datetime(6)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mail_verification", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    initials = table.Column<string>(type: "longtext", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_state", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tree",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    biomeid = table.Column<int>(name: "biome_id", type: "int", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    image = table.Column<string>(type: "longtext", nullable: false),
                    value = table.Column<double>(type: "double", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tree", x => x.id);
                    table.ForeignKey(
                        name: "fk_tree_biome_biome_id",
                        column: x => x.biomeid,
                        principalTable: "biome",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    stateid = table.Column<int>(name: "state_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_state_state_id",
                        column: x => x.stateid,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "partner",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    treeid = table.Column<int>(name: "tree_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_partner", x => x.id);
                    table.ForeignKey(
                        name: "fk_partner_tree_tree_id",
                        column: x => x.treeid,
                        principalTable: "tree",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    photo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    cityid = table.Column<int>(name: "city_id", type: "int", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    emailverified = table.Column<bool>(name: "email_verified", type: "tinyint(1)", nullable: false, defaultValue: false),
                    origin = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    allownewsletter = table.Column<bool>(name: "allow_newsletter", type: "tinyint(1)", nullable: false, defaultValue: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_city_city_id",
                        column: x => x.cityid,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "password_reset",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: false),
                    token = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    activatedat = table.Column<DateTime>(name: "activated_at", type: "datetime(6)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_password_reset", x => x.id);
                    table.ForeignKey(
                        name: "fk_password_reset_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    value = table.Column<double>(type: "double", nullable: false),
                    status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    paymentrequest = table.Column<string>(name: "payment_request", type: "longtext", nullable: false),
                    paymentresponse = table.Column<string>(name: "payment_response", type: "longtext", nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment", x => x.id);
                    table.ForeignKey(
                        name: "fk_payment_order_order_id",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plant",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    message = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    value = table.Column<double>(type: "double", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: false),
                    treeid = table.Column<int>(name: "tree_id", type: "int", nullable: false),
                    partnerid = table.Column<int>(name: "partner_id", type: "int", nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plant", x => x.id);
                    table.ForeignKey(
                        name: "fk_plant_order_order_id",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_plant_partner_partner_id",
                        column: x => x.partnerid,
                        principalTable: "partner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_plant_tree_tree_id",
                        column: x => x.treeid,
                        principalTable: "tree",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_plant_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plant_tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    plantid = table.Column<int>(name: "plant_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plant_tag", x => x.id);
                    table.ForeignKey(
                        name: "fk_plant_tag_plant_plant_id",
                        column: x => x.plantid,
                        principalTable: "plant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_city_state_id",
                table: "city",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_user_id",
                table: "order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_partner_tree_id",
                table: "partner",
                column: "tree_id");

            migrationBuilder.CreateIndex(
                name: "ix_password_reset_user_id",
                table: "password_reset",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_order_id",
                table: "payment",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_plant_order_id",
                table: "plant",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_plant_partner_id",
                table: "plant",
                column: "partner_id");

            migrationBuilder.CreateIndex(
                name: "ix_plant_tree_id",
                table: "plant",
                column: "tree_id");

            migrationBuilder.CreateIndex(
                name: "ix_plant_user_id",
                table: "plant",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_plant_tag_plant_id",
                table: "plant_tag",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tree_biome_id",
                table: "tree",
                column: "biome_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_city_id",
                table: "user",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrator");

            migrationBuilder.DropTable(
                name: "certificate");

            migrationBuilder.DropTable(
                name: "mail_verification");

            migrationBuilder.DropTable(
                name: "password_reset");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "plant_tag");

            migrationBuilder.DropTable(
                name: "plant");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "partner");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "tree");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "biome");

            migrationBuilder.DropTable(
                name: "state");
        }
    }
}
