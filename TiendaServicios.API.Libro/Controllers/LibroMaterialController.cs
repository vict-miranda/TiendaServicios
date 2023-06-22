using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.API.Libro.App;
using TiendaServicios.API.Libro.Models;

namespace TiendaServicios.API.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroMaterialDto>>> Get()
        {
            return await _mediator.Send(new Consulta.ListaLibroMaterial());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroMaterialDto>> GetById(Guid id)
        {
            return await _mediator.Send(new ConsultaFiltro.LibreriaMaterialUnico { LibreriaMaterialGuid = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
    }
}
