using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Autor.Models;

namespace TiendaServicios.API.Autor.Persistence
{
    public class ContextAutor : DbContext
    {
        public ContextAutor(DbContextOptions<ContextAutor> options) : base(options)
        {
            
        }

        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
