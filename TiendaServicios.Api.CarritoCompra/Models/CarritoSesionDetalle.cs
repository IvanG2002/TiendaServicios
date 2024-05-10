using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.CarritoCompra.Models
{
    public class CarritoSesionDetalle
    {
        [Key]
        public int CarritoSesionDetalleId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string ProductoSeleccionado { get; set; }
        public int CarritoSesionId { get; set; }
        public CarritoSession CarritoSesion {  get; set; }
    }
}
