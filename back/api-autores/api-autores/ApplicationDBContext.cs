using api_autores.Entitys;
using Microsoft.EntityFrameworkCore;

namespace api_autores
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        //configurando las tablas de la base de datos
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libro { get; set; } 
    }

}
