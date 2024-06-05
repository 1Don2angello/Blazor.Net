using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi83.Context
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions options):base(options)
       { }

        //Modelos a mapear 
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en tabla Usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Majo",
                    User = "Usuario",
                    Password= "123",
                    FKRol= 1 // Aqui debes el rol correspondiente

                });


            //Insertar en la tabla Roles

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa"
                });

        }
    }
}
