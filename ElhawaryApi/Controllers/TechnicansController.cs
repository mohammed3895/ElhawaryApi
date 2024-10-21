namespace ElhawaryApi.Controllers
{
    [Route("api/technicans")]
    [ApiController]
    public class TechnicansController(ITechnicansService technicansService, IMapper mapper) : Controller
    {
        private readonly ITechnicansService _technicansService = technicansService;
        public IMapper Mapper { get; } = mapper;

        [HttpGet]
        [Authorize]
        [Route("/api/technicans")]
        public ActionResult<List<TechnicanDTO>> GetAllTechnicans()
        {
            var list = _technicansService.GetAllTechnicans();

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        [HttpGet]
        [Authorize(Roles = "Owner")]
        [Route("/api/technicans/{id}", Name = "GetTechnicanById")]
        public async Task<ActionResult<TechnicanDTO>> GetTechnicanById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var technican = await _technicansService.GetTechnicanById(id);

            TechnicanDTO result = Mapper.Map<TechnicanDTO>(technican);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        [Route("/api/technicans/new", Name = "AddNew")]
        public ActionResult AddTechnican(TechnicanDTO technican)
        {
            if (technican == null)
            {
                return BadRequest();
            }

            Technicans t = Mapper.Map<Technicans>(technican);

            _technicansService.AddTechnican(t);
            return CreatedAtRoute(nameof(AddTechnican), new { id = t.Id }, t);
        }
    }
}
