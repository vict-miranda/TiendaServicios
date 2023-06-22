using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.API.Autor.App;
using TiendaServicios.API.Autor.Models;

namespace TiendaServicios.API.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorLibro>>> Get()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorLibro>> GetById([FromQuery] string id)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico{ AutorGuid = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
    }
}
