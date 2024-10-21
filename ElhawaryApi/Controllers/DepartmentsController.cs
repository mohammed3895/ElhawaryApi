namespace ElhawaryApi.Controllers
{
    public class DepartmentsController(IDepartmentsService departmentsService) : Controller
    {
        private readonly IDepartmentsService _departmentsService = departmentsService;

        [HttpGet]
        [Route("/api/departments")]
        public ActionResult<List<DepartmentDTO>> GetAllDepartments()
        {
            var list = _departmentsService.GetAllDepartments();

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        [HttpGet]
        [Route("/api/departments/{id}", Name = "GetDepartmentById")]
        public ActionResult<DepartmentDTO> GetDepartmentById(int? id)
        {
            var department = _departmentsService.GetDepartmentsById(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        [Route("/api/departments/new")]
        public async Task<ActionResult> AddNewDepartment(DepartmentDTO department)
        {
            if (department == null)
            {
                return BadRequest();
            }

            Department d = new()
            {
                Name = department.Name,
            };

            await _departmentsService.AddDepartment(d);

            return CreatedAtRoute(nameof(GetDepartmentById), new { id = d.Id }, d);
        }
    }
}
