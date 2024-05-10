using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Models;

namespace TiendaServicios.Api.CarritoCompra.Persistence
{
    public class CarritoContexto : DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options)
            : base(options)
        {
        }
        public DbSet<CarritoSession> Sessions { get; set; }
        public DbSet<CarritoSesionDetalle> SesionDetalles { get; set; }

    }
}
