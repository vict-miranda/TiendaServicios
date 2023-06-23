using FluentValidation;
using MediatR;
using TiendaServicios.API.Libro.Models;
using TiendaServicios.API.Libro.Persistence;

namespace TiendaServicios.API.Libro.App
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; } = string.Empty;
            public Guid? AutorLibro { get; set; }
            public DateTime? FechaPublicacion { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibro).NotEmpty();
            }
        }

        public class Manejeador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoLibreria _contexto;

            public Manejeador(ContextoLibreria contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = new LibreriaMaterial
                {
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    AutorLibroId = request.AutorLibro
                };

                _contexto.LibreriaMaterials.Add(libro);
                var valor = await _contexto.SaveChangesAsync(cancellationToken);

                if (valor > 0)
                    return Unit.Value;

                throw new Exception("No se pudo insertar Libro.");
            }
        }
    }
}
