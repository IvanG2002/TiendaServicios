using Microsoft.EntityFrameworkCore;
using TiendaServicios.api.Author.Models;

namespace TiendaServicios.api.Author.Persistence
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options)
            : base(options) { }

        public DbSet<AutorLibro> AutorLibros {  get; set; }
        public DbSet<GradoAcademico> GradoAcademicos { get; set; }
    }
}
