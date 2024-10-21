namespace ElhawaryApi.DI.Interfaces
{
    public interface IDepartmentsService
    {
        Task<List<DepartmentDTO>> GetAllDepartments();
        Task<DepartmentDTO> GetDepartmentsById(int? id);
        Task AddDepartment(Department department);
    }
}
