﻿// <auto-generated />
using System;
using FitnessCenter.BD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessCenter.Migrations
{
    [DbContext(typeof(BDContext))]
    [Migration("20230507103030_try add servisces table")]
    partial class tryaddserviscestable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AbonementsServices", b =>
                {
                    b.Property<Guid>("AbonementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServicesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AbonementId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("AbonementsServices");
                });

            modelBuilder.Entity("FitnessCenter.BD.EntitiesBD.Abonements", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Validity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abonements");
                });

            modelBuilder.Entity("FitnessCenter.BD.EntitiesBD.Clients", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("FitnessCenter.BD.EntitiesBD.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbonementsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbonementsId");

                    b.HasIndex("ClientsId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FitnessCenter.BD.EntitiesBD.Repositories.Services", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AbonementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("AbonementsServices", b =>
                {
                    b.HasOne("FitnessCenter.BD.EntitiesBD.Abonements", null)
                        .WithMany()
                        .HasForeignKey("AbonementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessCenter.BD.EntitiesBD.Repositories.Services", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessCenter.BD.EntitiesBD.Orders", b =>
                {
                    b.HasOne("FitnessCenter.BD.EntitiesBD.Abonements", "Abonement")
                        .WithMany("Orders")
                        .HasForeignKey("AbonementsId");

                    b.HasOne("FitnessCenter.BD.EntitiesBD.Clients", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientsId");

                    b.Navigation("Abonement");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("FitnessCenter.BD.EntitiesBD.Abonements", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FitnessCenter.BD.EntitiesBD.Clients", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
