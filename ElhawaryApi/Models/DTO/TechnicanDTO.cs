using ElhawaryApi.Models.Domain;

namespace ElhawaryApi.Models.DTO
{
    public class TechnicanDTO
    {
        public TechnicanDTO()
        {
            this.Id = -1;
            this.Name = "";
            this.Email = "";
            this.PhoneNumber = "";
            this.DepartmentId = -1;
        }
        public TechnicanDTO(int id, string name, string email, string phoneNumber, int departmentId, Department department)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DepartmentId = departmentId;
        }

        public int Id { get; }
        public string Name { get; set; }
        = string.Empty;
        public string Email { get; set; }
        = string.Empty;
        public string PhoneNumber { get; set; }
        = string.Empty;
        public int DepartmentId { get; set; }
    }
}
