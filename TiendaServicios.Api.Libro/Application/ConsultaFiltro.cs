using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Models;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Application
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDto>
        {
            public Guid? LibroId { get; set; }
        }
        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibroMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await _contexto.libreriaMaterials
                    .Where(x => x.LibreriaMaterialId == request.LibroId)
                    .FirstOrDefaultAsync();
                if (libro == null)
                {
                    throw new Exception("No se encontro el libro");
                }
                var libroDto = _mapper.Map<LibreriaMaterial, LibroMaterialDto>(libro);
                return libroDto;
            }
        }
    }
}
