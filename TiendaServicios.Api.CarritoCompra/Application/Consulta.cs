using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Persistence;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDto>
        {
            public int CarritoSesionId { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto _contexto;
            private readonly ILibroService _libroService;

            public Manejador(CarritoContexto contexto, ILibroService libroService)
            {
                _contexto = contexto;
                _libroService = libroService;
            }

            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await _contexto.Sessions
                    .FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);
                var carritoSessionDetalle = await _contexto.SesionDetalles
                    .Where(x => x.CarritoSesionId == request.CarritoSesionId).ToListAsync();
                var listCarritoDto = new List<CarritoDetalleDto>();
                foreach (var libro in carritoSessionDetalle)
                {
                    var resp = await _libroService.GetLibro(new Guid(libro.ProductoSeleccionado));
                    if (resp.resultado)
                    {
                        var objLibro = resp.Libro;
                        var carritoDetalle = new CarritoDetalleDto
                        {
                            TituloLibro = objLibro.Titulo,
                            FechaPublicacion = objLibro.FechaPublicacion,
                            LibroId = objLibro.LibreriaMaterialId,
                        };
                        listCarritoDto.Add(carritoDetalle);
                    }
                }
                var carritoSesionDto = new CarritoDto
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProducto = listCarritoDto
                };
                return carritoSesionDto;
            }
        }
    }
}
