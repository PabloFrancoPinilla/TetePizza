﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TetePizza.Data;

#nullable disable

namespace TetePizza.Data.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20240214185434_PizzaIngredientes")]
    partial class PizzaIngredientes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TetePizza.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Descripción de la cebolla",
                            IsVegan = true,
                            Name = "Cebolla",
                            Origin = "Vegetable",
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            Description = "Descripción del pepeorino",
                            IsVegan = false,
                            Name = "Pepeorino",
                            Origin = "Animal",
                            Stock = 100
                        });
                });

            modelBuilder.Entity("TetePizza.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsGlutenFree")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsGlutenFree = true,
                            Name = "Hawaiana"
                        },
                        new
                        {
                            Id = 2,
                            IsGlutenFree = true,
                            Name = "Barbacoa"
                        });
                });

            modelBuilder.Entity("TetePizza.Models.PizzaIngrediente", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "IngredienteId");

                    b.HasIndex("IngredienteId");

                    b.ToTable("PizzaIngrediente");

                    b.HasData(
                        new
                        {
                            PizzaId = 1,
                            IngredienteId = 1
                        },
                        new
                        {
                            PizzaId = 1,
                            IngredienteId = 2
                        });
                });

            modelBuilder.Entity("TetePizza.Models.PizzaIngrediente", b =>
                {
                    b.HasOne("TetePizza.Models.Ingrediente", "Ingrediente")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TetePizza.Models.Pizza", "Pizza")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("TetePizza.Models.Ingrediente", b =>
                {
                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("TetePizza.Models.Pizza", b =>
                {
                    b.Navigation("PizzaIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
