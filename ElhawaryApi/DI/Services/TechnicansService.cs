namespace ElhawaryApi.DI.Services
{
    public class TechnicansService(AppDbcontext context) : ITechnicansService
    {
        private readonly AppDbcontext _context = context;

        public Task AddTechnican(Technicans technican)
        {
            try
            {
                _context.Add(technican);
                _context.SaveChanges();
                return Task.CompletedTask;
            } catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public List<TechnicanDTO> GetAllTechnicans()
        {
            var list = _context.Technicans.ToList();
            List<TechnicanDTO> technicans = [];

            try
            {
                foreach (var item in list)
                {
                    technicans.Add(new(
                        id: item.Id,
                        name: item.Name,
                        email: item.Email,
                        phoneNumber: item.PhoneNumber,
                        departmentId: item.DepartmentId,
                        department: item.Department!
                    ));
                }
                return technicans;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/technicans/{id}")]
        public async Task<Technicans> GetTechnicanById(int? id)
        {
            try
            {
                var technican = await _context.Technicans.Include("Department").FirstOrDefaultAsync(t => t.Id == id);
                return technican ?? throw new Exception(message: $"No Technican found with id: {id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
