namespace ElhawaryApi.DI.Services
{
    public class DepartmentsService(AppDbcontext context) : IDepartmentsService
    {
        private readonly AppDbcontext _context = context;

        public async Task AddDepartment(Department department)
        {
            try
            {
                await _context.AddAsync(department);
                _context.SaveChanges();

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<DepartmentDTO>> GetAllDepartments()
        {
            var list = await _context.Departments.ToListAsync();
            List<DepartmentDTO> departments = [];

            try
            {
                foreach (var item in list)
                {
                    departments.Add(new()
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
                return departments;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<DepartmentDTO> GetDepartmentsById(int? id)
        {
            try
            {
                var dept = await _context.Departments.FirstOrDefaultAsync(de => de.Id == id) 
                    ?? throw new Exception($"No Department found with id: {id}");

                DepartmentDTO departmentDTO = new()
                {
                    Id = dept.Id,
                    Name = dept.Name,
                };

                return departmentDTO;
            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
