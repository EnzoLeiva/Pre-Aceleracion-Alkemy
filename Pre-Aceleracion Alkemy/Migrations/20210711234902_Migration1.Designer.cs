﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pre_Aceleracion_Alkemy.Pre_AceleracionData;

namespace Pre_Aceleracion_Alkemy.Migrations
{
    [DbContext(typeof(Pre_AceleracionDb))]
    [Migration("20210711234902_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeliculaPersonaje", b =>
                {
                    b.Property<int>("PeliculasAsociadosPeliculaID")
                        .HasColumnType("int");

                    b.Property<int>("PersonajesAsociadasPersonajeID")
                        .HasColumnType("int");

                    b.HasKey("PeliculasAsociadosPeliculaID", "PersonajesAsociadasPersonajeID");

                    b.HasIndex("PersonajesAsociadasPersonajeID");

                    b.ToTable("PeliculaPersonaje");
                });

            modelBuilder.Entity("Pre_Aceleracion_Alkemy.Models.Genders", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderID");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Pre_Aceleracion_Alkemy.Models.Movies", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GenderID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieID");

                    b.HasIndex("GenderID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Pre_Aceleracion_Alkemy.Models.Characters", b =>
                {
                    b.Property<int>("CharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Story")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CharacterID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("PeliculaPersonaje", b =>
                {
                    b.HasOne("Pre_Aceleracion_Alkemy.Models.Movies", null)
                        .WithMany()
                        .HasForeignKey("PeliculasAsociadosPeliculaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pre_Aceleracion_Alkemy.Models.Characters", null)
                        .WithMany()
                        .HasForeignKey("PersonajesAsociadasPersonajeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pre_Aceleracion_Alkemy.Models.Movies", b =>
                {
                    b.HasOne("Pre_Aceleracion_Alkemy.Models.Genders", null)
                        .WithMany("Movies")
                        .HasForeignKey("GenderID");
                });

            modelBuilder.Entity("Pre_Aceleracion_Alkemy.Models.Genders", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
