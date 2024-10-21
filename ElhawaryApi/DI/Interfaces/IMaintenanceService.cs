
using ElhawaryApi.Events;

namespace ElhawaryApi.DI.Interfaces
{
    public interface IMaintenanceService
    {
        public event EventHandler<MaintenanceEventArgs> MaintenanceCreated;
        Task<List<MaintenanceDTO>> GetMaintenanceList();
        Task<Maintenance> GetMaintenanceById(int id);
        Task AddNewDeviceToMaintenance(MaintenanceDTO newDevice);
        Task UpdateMaintenance(int id, MaintenanceDTO newDevice);
        Task<bool> DeleteMaintenance(int? id);
    }
}
