﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimeraPruebaTarea5.Dal;

namespace PrimeraPruebaTarea5.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("PrimeraPruebaTarea5.Entidades.Permisos", b =>
                {
                    b.Property<int>("IdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombrePermiso")
                        .HasColumnType("TEXT");

                    b.HasKey("IdPermiso");

                    b.ToTable("Permisos");

                    b.HasData(
                        new
                        {
                            IdPermiso = 1,
                            NombrePermiso = "Descuenta"
                        },
                        new
                        {
                            IdPermiso = 2,
                            NombrePermiso = "Vende"
                        },
                        new
                        {
                            IdPermiso = 3,
                            NombrePermiso = "Cobra"
                        });
                });

            modelBuilder.Entity("PrimeraPruebaTarea5.Entidades.Roles", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EsActivo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreRol")
                        .HasColumnType("TEXT");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PrimeraPruebaTarea5.Entidades.RolesDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPermiso")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdRol")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("esAsignado")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdRol");

                    b.ToTable("RolesDetalle");
                });

            modelBuilder.Entity("PrimeraPruebaTarea5.Entidades.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AliasUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaveUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaUSuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdRol")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("TEXT");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PrimeraPruebaTarea5.Entidades.Permisos", b =>
                {
                    b.HasOne("PrimeraPruebaTarea5.Entidades.Permisos", "Permiso")
                        .WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");
                });

            modelBuilder.Entity("PrimeraPruebaTarea5.Entidades.RolesDetalle", b =>
                {
                    b.HasOne("PrimeraPruebaTarea5.Entidades.Roles", null)
                        .WithMany("Detalle")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimeraPruebaTarea5.Entidades.Roles", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
