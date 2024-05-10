using MediatR;
using TiendaServicios.Api.CarritoCompra.Models;
using TiendaServicios.Api.CarritoCompra.Persistence;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ProductoLista { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto _contexto;

            public Manejador(CarritoContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSession
                {
                    FechaCreacion = request.FechaCreacionSesion,
                };
                _contexto.Sessions.Add(carritoSesion);
                int value = await _contexto.SaveChangesAsync();
                if (value == 0)
                    throw new Exception("Error en la insercion");
                int id = carritoSesion.CarritoSesionId;
                foreach (var obj in request.ProductoLista)
                {
                    var detalleSesion = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = obj
                    };
                    _contexto.SesionDetalles.Add(detalleSesion);
                }
                value = await _contexto.SaveChangesAsync();
                if (value > 0)
                    return Unit.Value;
                throw new Exception("No se pudo insertar");
            }
        }
    }
}
