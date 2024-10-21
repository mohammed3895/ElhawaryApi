namespace ElhawaryApi.Models.DTO
{
    public class DepartmentDTO
    {
        public DepartmentDTO(int id, string name, ICollection<Technicans> technicans)
        {
            this.Id = id;
            this.Name = name;
            this.Technicans = technicans;
        }

        public DepartmentDTO()
        {
            this.Id = -1;
            this.Name = "";
            this.Technicans = [];
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Technicans> Technicans { get; set; } = [];
    }
}
