namespace AppForSEII.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Modelos3DController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<Modelos3DController> _logger;

        public Modelos3DController(ApplicationDbContext context, ILogger<Modelos3DController> logger)
        {
            _context = context;
            _logger = logger;

        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(IList<Modelo3D>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetModelos3D()
        {
            List<Modelo3D> modelos3d = await _context.Modelos3D.ToListAsync();
            return Ok(modelos3d);
        }
    }
}