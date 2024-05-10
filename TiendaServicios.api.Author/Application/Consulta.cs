using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.api.Author.Models;
using TiendaServicios.api.Author.Persistence;

namespace TiendaServicios.api.Author.Application
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDto>>
        {
        }
        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibros.ToListAsync();
                var autoresDto = _mapper.Map<List<AutorLibro>, List<AutorDto>>(autores);
                return autoresDto;
            }
        }
    }
}
