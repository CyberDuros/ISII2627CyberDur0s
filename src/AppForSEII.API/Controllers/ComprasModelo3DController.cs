using AppForSEII.API.DTOs.CompraModelo3DDTOs;

namespace AppForSEII.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasModelo3DController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ComprasModelo3DController> _logger;

        public ComprasModelo3DController(ApplicationDbContext context, ILogger<ComprasModelo3DController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(CompraModelo3DDetalleDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetDetallesCompraModelo3D(int id)
        {
            var compraModelo3D = await _context.ComprasModelos3D
            .Where(cm => cm.Id == id)
                .Include(cm => cm.LineasCompra)
                    .ThenInclude(lc => lc.Modelo3D)
                        .ThenInclude(modelo3d => modelo3d.Licencia)
            .Select(cm => new CompraModelo3DDetalleDTO(cm.Id, cm.FechaCompra, cm.NombreCliente, cm.ApellidosCliente,
                                                       cm.CorreoElectronico, cm.DireccionFacturacion, cm.MetodoPago,
                                                       cm.Descripcion, 
                                                       cm.LineasCompra
                                                            .Select(lc => new LineaCompraModeloDTO(lc.Modelo3DId, 
                                                                                                   lc.Modelo3D.Nombre, 
                                                                                                   lc.Modelo3D.Categoria, 
                                                                                                   lc.Modelo3D.Formato,
                                                                                                   lc.PrecioUnidad,
                                                                                                   lc.CantidadLicencias,
                                                                                                   lc.Modelo3D.Licencia.FechaExpiracion)).ToList()))
            .FirstOrDefaultAsync();

            if(compraModelo3D == null)
            {
                _logger.LogError($"Error: CompraModelo3D con id {id} no existe");
                return NotFound();
            }

            return Ok(compraModelo3D);
        }
    }    
}