﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyExchange.Data;

#nullable disable

namespace MyExchange.Data.Migrations
{
    [DbContext(typeof(MyExchangeContext))]
    partial class MyExchangeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyExchange.Domain.Entities.BankCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cvv")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<long>("Number")
                        .HasMaxLength(16)
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TerminalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("BankCardId");

                    b.HasIndex("UserId");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MarketType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PriceUsd")
                        .HasColumnType("decimal(38,19)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id")
                        .HasName("CurrencyId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id")
                        .HasName("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("WalletId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.WalletBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("UAH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,19)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("USD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,19)")
                        .HasDefaultValue(0m);

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("WalletBalanceId");

                    b.HasIndex("WalletId")
                        .IsUnique();

                    b.ToTable("WalletBalance");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.WalletPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("ClosePrice")
                        .HasColumnType("decimal(38,19)");

                    b.Property<decimal?>("ClosedMargin")
                        .HasColumnType("decimal(38,19)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentMargin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,19)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("EntryPrice")
                        .HasColumnType("decimal(38,19)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(38,19)");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("WalletPositionId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("WalletId");

                    b.ToTable("WalletPositions");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.WalletStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("TotalAmoundEnrollment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,19)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("TotalAmoundWithdrawl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,19)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("TotalClosedMargin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,19)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("TotalCurrentCapital")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,19)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("TotalCurrentMargin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,19)")
                        .HasDefaultValue(0m);

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("WalletStatisticId");

                    b.HasIndex("WalletId")
                        .IsUnique();

                    b.ToTable("WalletStatistic");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.BankCard", b =>
                {
                    b.HasOne("MyExchange.Domain.Entities.User", "User")
                        .WithMany("BankCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.Wallet", b =>
                {
                    b.HasOne("MyExchange.Domain.Entities.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("MyExchange.Domain.Entities.Wallet", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.WalletBalance", b =>
                {
                    b.HasOne("MyExchange.Domain.Entities.Wallet", "Wallet")
                        .WithOne("WalletBalance")
                        .HasForeignKey("MyExchange.Domain.Entities.WalletBalance", "WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.WalletPosition", b =>
                {
                    b.HasOne("MyExchange.Domain.Entities.Currency", "Currency")
                        .WithMany("WalletPositions")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyExchange.Domain.Entities.Wallet", "Wallet")
                        .WithMany("WalletPositions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.WalletStatistic", b =>
                {
                    b.HasOne("MyExchange.Domain.Entities.Wallet", "Wallet")
                        .WithOne("WalletStatistic")
                        .HasForeignKey("MyExchange.Domain.Entities.WalletStatistic", "WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.Currency", b =>
                {
                    b.Navigation("WalletPositions");
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.User", b =>
                {
                    b.Navigation("BankCards");

                    b.Navigation("Wallet")
                        .IsRequired();
                });

            modelBuilder.Entity("MyExchange.Domain.Entities.Wallet", b =>
                {
                    b.Navigation("WalletBalance")
                        .IsRequired();

                    b.Navigation("WalletPositions");

                    b.Navigation("WalletStatistic")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
