using FluentValidation;
using MediatR;
using TiendaServicios.API.Autor.Models;
using TiendaServicios.API.Autor.Persistence;

namespace TiendaServicios.API.Autor.App
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }  
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }

        public class Manejeador : IRequestHandler<Ejecuta>
        {
            public readonly ContextAutor _contexto;

            public Manejeador(ContextAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,    
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };

                _contexto.AutorLibro.Add(autorLibro);
                var valor = await _contexto.SaveChangesAsync(cancellationToken);

                if (valor > 0)
                    return Unit.Value;

                throw new Exception("No se pudo insertar Autor Libro.");
            }
        }
    }
}
