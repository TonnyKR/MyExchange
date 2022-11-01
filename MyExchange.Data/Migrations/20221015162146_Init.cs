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
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BankId", x => x.Id);
                });

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
                name: "PromoCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PromoCodeId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoCode_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletType = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCurrentCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalEnrolment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalWithdrawl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCurrentMargin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalClosedMargin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "BankCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(type: "bigint", maxLength: 16, nullable: false),
                    TerminalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cvv = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BankCardId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCards_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankCards_Wallets_WalletId",
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
                name: "WalletsPromoCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoCodeId = table.Column<int>(type: "int", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WalletsPromoCodesId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletsPromoCodes_PromoCode_PromoCodeId",
                        column: x => x.PromoCodeId,
                        principalTable: "PromoCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletsPromoCodes_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_BankId",
                table: "BankCards",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_WalletId",
                table: "BankCards",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCode_CurrencyId",
                table: "PromoCode",
                column: "CurrencyId");

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
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletsPromoCodes_PromoCodeId",
                table: "WalletsPromoCodes",
                column: "PromoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletsPromoCodes_WalletId",
                table: "WalletsPromoCodes",
                column: "WalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "WalletPositions");

            migrationBuilder.DropTable(
                name: "WalletsPromoCodes");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "PromoCode");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
