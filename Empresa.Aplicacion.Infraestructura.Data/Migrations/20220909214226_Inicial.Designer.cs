// <auto-generated />
using System;
using Empresa.Aplicacion.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Empresa.Aplicacion.Infraestructura.Data.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    [Migration("20220909214226_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Empresa.Aplicacion.Domain.Entity.Calificacion", b =>
                {
                    b.Property<int>("Calificacion_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Calificacion_Id"), 1L, 1);

                    b.Property<string>("Clasificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Usuario_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Valor_Calificacion")
                        .HasColumnType("int");

                    b.HasKey("Calificacion_Id");

                    b.HasIndex("Calificacion_Id");

                    b.ToTable("Calificacion");

                    b.HasData(
                        new
                        {
                            Calificacion_Id = 1,
                            Clasificacion = "",
                            Usuario_Id = 2
                        },
                        new
                        {
                            Calificacion_Id = 2,
                            Clasificacion = "",
                            Usuario_Id = 3
                        },
                        new
                        {
                            Calificacion_Id = 3,
                            Clasificacion = "",
                            Usuario_Id = 4
                        },
                        new
                        {
                            Calificacion_Id = 4,
                            Clasificacion = "",
                            Usuario_Id = 5
                        },
                        new
                        {
                            Calificacion_Id = 5,
                            Clasificacion = "",
                            Usuario_Id = 6
                        });
                });

            modelBuilder.Entity("Empresa.Aplicacion.Domain.Entity.Perfil", b =>
                {
                    b.Property<int>("Perfil_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Perfil_Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Perfil_Id");

                    b.HasIndex("Perfil_Id");

                    b.ToTable("Perfil");

                    b.HasData(
                        new
                        {
                            Perfil_Id = 1,
                            Descripcion = "Administrador"
                        },
                        new
                        {
                            Perfil_Id = 2,
                            Descripcion = "Votante"
                        });
                });

            modelBuilder.Entity("Empresa.Aplicacion.Domain.Entity.Usuario", b =>
                {
                    b.Property<int>("Usuario_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Usuario_Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil_Id")
                        .HasColumnType("int");

                    b.HasKey("Usuario_Id");

                    b.HasIndex("Perfil_Id");

                    b.HasIndex("Usuario_Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Usuario_Id = 1,
                            Apellidos = "Admin",
                            Login = "admin",
                            Nombres = "Admin",
                            Password = "123456",
                            Perfil_Id = 1
                        },
                        new
                        {
                            Usuario_Id = 2,
                            Apellidos = "Usuario 1",
                            Login = "Usuario1",
                            Nombres = "Usuario 1",
                            Password = "123456",
                            Perfil_Id = 2
                        },
                        new
                        {
                            Usuario_Id = 3,
                            Apellidos = "Usuario 2",
                            Login = "Usuario2",
                            Nombres = "Usuario 2",
                            Password = "123456",
                            Perfil_Id = 2
                        },
                        new
                        {
                            Usuario_Id = 4,
                            Apellidos = "Usuario 3",
                            Login = "Usuario3",
                            Nombres = "Usuario 3",
                            Password = "123456",
                            Perfil_Id = 2
                        },
                        new
                        {
                            Usuario_Id = 5,
                            Apellidos = "Usuario 4",
                            Login = "Usuario4",
                            Nombres = "Usuario 4",
                            Password = "123456",
                            Perfil_Id = 2
                        },
                        new
                        {
                            Usuario_Id = 6,
                            Apellidos = "Usuario 5",
                            Login = "Usuario5",
                            Nombres = "Usuario 5",
                            Password = "123456",
                            Perfil_Id = 2
                        });
                });

            modelBuilder.Entity("Empresa.Aplicacion.Domain.Entity.Usuario", b =>
                {
                    b.HasOne("Empresa.Aplicacion.Domain.Entity.Perfil", "Perfil")
                        .WithMany("lst_Usuarios")
                        .HasForeignKey("Perfil_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("Empresa.Aplicacion.Domain.Entity.Perfil", b =>
                {
                    b.Navigation("lst_Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
