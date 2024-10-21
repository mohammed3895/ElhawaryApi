namespace ElhawaryApi.DI.Interfaces
{
    public interface IMaintenanceStatusService
    {
        Task<MaintenanceStatus> AddNewStatus(MaintenanceStatus status);
    }
}
