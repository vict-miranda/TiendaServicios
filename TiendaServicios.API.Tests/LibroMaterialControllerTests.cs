using MediatR;
using Telerik.JustMock;
using TiendaServicios.API.Libro.App;
using TiendaServicios.API.Libro.Controllers;

namespace TiendaServicios.API.Tests
{
    public class LibroMaterialControllerTests
    {
        private IMediator _mediator;
        private LibroMaterialController _libroMaterialController;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Create<IMediator>();
            _libroMaterialController = new LibroMaterialController(_mediator);
        }

        [Test]
        public async Task Test1()
        {
            Mock.Arrange(() => _mediator.Send(new Consulta.ListaLibroMaterial(), Arg.IsAny<CancellationToken>())).ReturnsAsync(new List<LibroMaterialDto> { new LibroMaterialDto { Titulo = "Victor" } });


            var response = await _libroMaterialController.Get();

            Assert.IsNotNull(response);
            //Assert.IsTrue(response. > 0);
        }
    }
}