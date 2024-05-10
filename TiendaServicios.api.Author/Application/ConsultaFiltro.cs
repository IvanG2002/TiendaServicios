using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.api.Author.Models;
using TiendaServicios.api.Author.Persistence;

namespace TiendaServicios.api.Author.Application
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }
        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibros
                    .Where(x => x.AutorLibroGuid == request.AutorGuid)
                    .FirstOrDefaultAsync();
                if (autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                var autorDto = _mapper.Map<AutorLibro, AutorDto>(autor);
                return autorDto;
            }
        }
    }
}
