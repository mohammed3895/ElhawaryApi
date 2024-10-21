namespace ElhawaryApi.DI.Interfaces
{
    public interface ITechnicansService
    {
        List<TechnicanDTO> GetAllTechnicans();
        Task<Technicans> GetTechnicanById(int? id);
        Task AddTechnican(Technicans technican);
    }
}
