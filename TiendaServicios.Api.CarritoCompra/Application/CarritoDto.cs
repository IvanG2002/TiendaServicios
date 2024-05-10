namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class CarritoDto
    {
        public int CarritoId { get; set; }
        public DateTime? FechaCreacionSesion { get; set; }
        public List<CarritoDetalleDto> ListaProducto { get; set; }
    }
}
