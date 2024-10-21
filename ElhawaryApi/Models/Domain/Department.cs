namespace ElhawaryApi.Models.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Technicans> Technicans { get; set; } = [];
    }
}
