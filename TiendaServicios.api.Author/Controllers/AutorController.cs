using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.api.Author.Application;
using TiendaServicios.api.Author.Models;

namespace TiendaServicios.api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public AutorController(IMediator mediator)
        {
            _mediatR = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediatR.Send(data);
        }
        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetAutores()
        {
            return await _mediatR.Send(new Consulta.ListaAutor());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutorLibro(string id)
        {
            return await _mediatR.Send(new ConsultaFiltro.AutorUnico { AutorGuid = id});
        }
    }
}
