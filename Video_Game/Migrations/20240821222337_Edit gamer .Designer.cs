﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Video_Game.Data;

#nullable disable

namespace Video_Game.Migrations
{
    [DbContext(typeof(CardDbContext))]
    [Migration("20240821222337_Edit gamer ")]
    partial class Editgamer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GamesOrder", b =>
                {
                    b.Property<int>("GamesGameID")
                        .HasColumnType("int");

                    b.Property<int>("OrdersOrderID")
                        .HasColumnType("int");

                    b.HasKey("GamesGameID", "OrdersOrderID");

                    b.HasIndex("OrdersOrderID");

                    b.ToTable("GamesOrder");
                });

            modelBuilder.Entity("Video_Game.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Video_Game.Models.Gamer", b =>
                {
                    b.Property<int>("GamerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GamerID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GamerID");

                    b.HasIndex("SubscriptionId")
                        .IsUnique()
                        .HasFilter("[SubscriptionId] IS NOT NULL");

                    b.ToTable("Gamers");
                });

            modelBuilder.Entity("Video_Game.Models.Games", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameID"));

                    b.Property<int>("GamerID")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameID");

                    b.HasIndex("GamerID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Video_Game.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("GamerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("GamerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Video_Game.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionID"));

                    b.Property<DateTime>("EndtDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SubscriptionID");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("GamesOrder", b =>
                {
                    b.HasOne("Video_Game.Models.Games", null)
                        .WithMany()
                        .HasForeignKey("GamesGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Video_Game.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Video_Game.Models.Gamer", b =>
                {
                    b.HasOne("Video_Game.Models.Subscription", "Subscription")
                        .WithOne("Gamer")
                        .HasForeignKey("Video_Game.Models.Gamer", "SubscriptionId");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Video_Game.Models.Games", b =>
                {
                    b.HasOne("Video_Game.Models.Gamer", "Gamer")
                        .WithMany("Games")
                        .HasForeignKey("GamerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gamer");
                });

            modelBuilder.Entity("Video_Game.Models.Order", b =>
                {
                    b.HasOne("Video_Game.Models.Gamer", "Gamer")
                        .WithMany("Orders")
                        .HasForeignKey("GamerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gamer");
                });

            modelBuilder.Entity("Video_Game.Models.Gamer", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Video_Game.Models.Subscription", b =>
                {
                    b.Navigation("Gamer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
