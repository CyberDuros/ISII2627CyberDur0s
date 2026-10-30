using AppForSEII.API.Controllers;
using AppForSEII.API.DTOs.AccesorioDTOs;

namespace AppForSEII.UT.AccesoriosController_test
{
    public class GetAccesoriosParaComprar_test : AppForSEII4SqliteUT
    {
        public GetAccesoriosParaComprar_test()
        {
            var accesorios = new List<Accesorio>()
            {
                new Accesorio("Boquilla de laton", CategoriaAccesorio.Boquillas, "Ender 3", 30, 2.50m),
                new Accesorio("Espatula", CategoriaAccesorio.Herramientas, "Todas", 15, 6.75m),
                new Accesorio("Boquilla templada", CategoriaAccesorio.Boquillas, "Prusa MK4", 10, 8.00m),
                new Accesorio("Kit de limpieza", CategoriaAccesorio.KitsLimpieza, "Todas", 0, 5.00m), //esto es inventado no tiene que devolver nunca nada 
            };                                                                                        // ya que la cantidad disponible es 0
            _context.AddRange(accesorios);
            _context.SaveChanges();
        }

        public static IEnumerable<object?[]> TestCasesFor_GetAccesoriosParaComprar()
        {
            var accesorioDTOs = new List<AccesorioParaComprarDTO>()
            {
                new AccesorioParaComprarDTO(1, "Boquilla de laton", CategoriaAccesorio.Boquillas, "Ender 3", 30, 2.50m),
                new AccesorioParaComprarDTO(2, "Espatula", CategoriaAccesorio.Herramientas, "Todas", 15, 6.75m),
                new AccesorioParaComprarDTO(3, "Boquilla templada", CategoriaAccesorio.Boquillas, "Prusa MK4", 10, 8.00m),
            };

            //sin filtros: todos los que tienen stock, ordenados por nombre
            var todos = new List<AccesorioParaComprarDTO>() { accesorioDTOs[0], accesorioDTOs[2], accesorioDTOs[1] };
            //filtro por nombre
            var porNombre = new List<AccesorioParaComprarDTO>() { accesorioDTOs[0], accesorioDTOs[2] };
            //filtro por categoria
            var porCategoria = new List<AccesorioParaComprarDTO>() { accesorioDTOs[1] };
            //filtro por nombre y categoria
            var porNombreYCategoria = new List<AccesorioParaComprarDTO>() { accesorioDTOs[0] };
            //el accesorio existe pero no tiene stock
            var ninguno = new List<AccesorioParaComprarDTO>();

            var allTests = new List<object?[]>
            {
                new object?[] { null, null, todos },
                new object?[] { "Boquilla", null, porNombre },
                new object?[] { null, CategoriaAccesorio.Herramientas, porCategoria },
                new object?[] { "laton", CategoriaAccesorio.Boquillas, porNombreYCategoria },
                new object?[] { "Kit", null, ninguno },
            };
            return allTests;
        }

        [Theory]
        [MemberData(nameof(TestCasesFor_GetAccesoriosParaComprar))]
        public async Task GetAccesoriosParaComprar_Filtros_test(string? nombre, CategoriaAccesorio? categoria,
            IList<AccesorioParaComprarDTO> accesoriosEsperados)
        {
            // Arrange
            var mock = new Mock<ILogger<AccesoriosController>>();
            ILogger<AccesoriosController> logger = mock.Object;
            var controller = new AccesoriosController(_context, logger);

            // Act
            var result = await controller.GetAccesoriosParaComprar(nombre, categoria);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var accesoriosActuales = Assert.IsType<List<AccesorioParaComprarDTO>>(okResult.Value);
            Assert.Equal(accesoriosEsperados, accesoriosActuales);
        }
    }
}