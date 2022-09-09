using Empresa.Aplicacion.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Infraestructura.Data.Configuration
{
    public class UsuarioConfiguration
    {
        public UsuarioConfiguration(EntityTypeBuilder<Usuario> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Usuario_Id);
            this.SeedUsuario(entityBuilder);
        }

        private void SeedUsuario(EntityTypeBuilder<Usuario> entityBuilder)
        {
            Usuario usuario = new Usuario()
            {
                Usuario_Id = 1,
                Apellidos = "Admin",
                Nombres = "Admin",
                Password = "123456",
                Login = "admin",
                Perfil_Id = 1
            };
            entityBuilder.HasData(usuario);

            usuario = new Usuario()
            {
                Usuario_Id = 2,
                Apellidos = "Usuario 1",
                Nombres = "Usuario 1",
                Password = "123456",
                Login = "Usuario1",
                Perfil_Id = 2
            };
            entityBuilder.HasData(usuario);

            usuario = new Usuario()
            {
                Usuario_Id = 3,
                Apellidos = "Usuario 2",
                Nombres = "Usuario 2",
                Password = "123456",
                Login = "Usuario2",
                Perfil_Id = 2
            };
            entityBuilder.HasData(usuario);

            usuario = new Usuario()
            {
                Usuario_Id = 4,
                Apellidos = "Usuario 3",
                Nombres = "Usuario 3",
                Password = "123456",
                Login = "Usuario3",
                Perfil_Id = 2
            };
            entityBuilder.HasData(usuario);

            usuario = new Usuario()
            {
                Usuario_Id = 5,
                Apellidos = "Usuario 4",
                Nombres = "Usuario 4",
                Password = "123456",
                Login = "Usuario4",
                Perfil_Id = 2
            };
            entityBuilder.HasData(usuario);

            usuario = new Usuario()
            {
                Usuario_Id = 6,
                Apellidos = "Usuario 5",
                Nombres = "Usuario 5",
                Password = "123456",
                Login = "Usuario5",
                Perfil_Id = 2
            };
            entityBuilder.HasData(usuario);
        }
    }
}
