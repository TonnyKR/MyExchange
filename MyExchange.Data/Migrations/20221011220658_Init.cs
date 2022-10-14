using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyExchange.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PriceUsd = table.Column<decimal>(type: "decimal(38,19)", nullable: false),
                    MarketType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CurrencyId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(type: "bigint", maxLength: 16, nullable: false),
                    TerminalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cvv = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BankCardId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WalletId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletBalance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USD = table.Column<decimal>(type: "decimal(38,19)", nullable: false, defaultValue: 0m),
                    UAH = table.Column<decimal>(type: "decimal(38,19)", nullable: false, defaultValue: 0m),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WalletBalanceId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletBalance_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(38,19)", nullable: false),
                    EntryPrice = table.Column<decimal>(type: "decimal(38,19)", nullable: false),
                    ClosePrice = table.Column<decimal>(type: "decimal(38,19)", nullable: true),
                    CurrentMargin = table.Column<decimal>(type: "decimal(38,19)", nullable: false, defaultValue: 0m),
                    ClosedMargin = table.Column<decimal>(type: "decimal(38,19)", nullable: true),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WalletPositionId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletPositions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletPositions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletStatistic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCurrentCapital = table.Column<decimal>(type: "decimal(38,19)", nullable: false, defaultValue: 0m),
                    TotalAmoundEnrollment = table.Column<decimal>(type: "decimal(38,19)", nullable: false, defaultValue: 0m),
                    TotalAmoundWithdrawl = table.Column<decimal>(type: "decimal(38,19)", nullable: false, defaultValue: 0m),
                    TotalCurrentMargin = table.Column<decimal>(type: "decimal(38,19)", nullable: false, defaultValue: 0m),
                    TotalClosedMargin = table.Column<decimal>(type: "decimal(38,19)", nullable: false, defaultValue: 0m),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WalletStatisticId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletStatistic_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_UserId",
                table: "BankCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletBalance_WalletId",
                table: "WalletBalance",
                column: "WalletId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletPositions_CurrencyId",
                table: "WalletPositions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletPositions_WalletId",
                table: "WalletPositions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletStatistic_WalletId",
                table: "WalletStatistic",
                column: "WalletId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "WalletBalance");

            migrationBuilder.DropTable(
                name: "WalletPositions");

            migrationBuilder.DropTable(
                name: "WalletStatistic");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
