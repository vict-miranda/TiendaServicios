using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Libro.Models;

namespace TiendaServicios.API.Libro.Persistence
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
        {
            
        }

        public DbSet<LibreriaMaterial> LibreriaMaterials { get; set; }
    }
}
