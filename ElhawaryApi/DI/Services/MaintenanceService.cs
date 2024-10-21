using ElhawaryApi.Events;

namespace ElhawaryApi.DI.Services
{
    public class MaintenanceService(AppDbcontext context, IMaintenanceStatusService maintenanceStatus) : IMaintenanceService
    {
        private readonly AppDbcontext _context = context;
        private readonly IMaintenanceStatusService _maintenanceStatus = maintenanceStatus;
        public event EventHandler<MaintenanceEventArgs> MaintenanceCreated;

        protected virtual void OnMaintenanceCreated(MaintenanceEventArgs args)
        {
            MaintenanceCreated?.Invoke(this, args);
        }

        // ADD NEW DATA TO LIST
        public async Task AddNewDeviceToMaintenance(MaintenanceDTO newDevice)
        {
            try
            {
                if (newDevice == null)
                    throw new Exception("null value is not accepted");

                Maintenance maintenance = new()
                {
                    CustomerName = newDevice.CustomerName,
                    DeviceModel = newDevice.DeviceModel,
                    CustomerPhoneNumber = newDevice.CustomerPhoneNumber,
                    IssueType = newDevice.IssueType,
                    IssueFees = newDevice.IssueFees,
                    PieceOrginalFee = newDevice.PieceOrginalFee,
                    Notes = newDevice.Notes,
                    MaintenanceType = newDevice.MaintenanceType,
                    RecievedAt = newDevice.RecievedAt,
                    DeleveredAt = newDevice.DeleveredAt,
                    Status = newDevice.Status,
                };

                await _context.AddAsync(maintenance);
                await _context.SaveChangesAsync();

                // EVENT PUBLISHER
                OnMaintenanceCreated(new MaintenanceEventArgs(maintenance));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE SINGLE ROW
        public async Task<bool> DeleteMaintenance(int? id)
        {
            try
            {
                Maintenance? maintenance = await _context.MaintenanceDepartment.FirstOrDefaultAsync(x => x.Id == id);

                if (maintenance == null)
                    return false;

                _context.MaintenanceDepartment.Remove(maintenance);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET SINGLE ROW
        public async Task<Maintenance> GetMaintenanceById(int id)
        {
            try
            {
                if (id < 0)
                    throw new Exception($"Error! Invalid id");

                Maintenance maintenace = await _context.MaintenanceDepartment
                    .Include("Status").FirstOrDefaultAsync(x => x.Id == id) 
                    ?? throw new Exception($"No data found with given id: {id}");

                return maintenace;
            }
            catch (Exception ex)
            {
                throw new Exception($"Sorry! An Error happend: {ex.Message}");
            }
        }

        public async Task<List<MaintenanceDTO>> GetMaintenanceList()
        {
            var list = await _context.MaintenanceDepartment.ToListAsync();
            List<MaintenanceDTO> maintenanceDTOs = [];

            try
            {
                foreach (var item in list)
                {
                    maintenanceDTOs.Add(new()
                    {
                        CustomerName = item.CustomerName,
                        DeviceModel = item.DeviceModel,
                        CustomerPhoneNumber = item.CustomerPhoneNumber,
                        IssueType = item.IssueType,
                        IssueFees = item.IssueFees,
                        PieceOrginalFee = item.PieceOrginalFee,
                        Notes = item.Notes,
                        MaintenanceType = item.MaintenanceType,
                        RecievedAt = item.RecievedAt,
                        DeleveredAt = item.DeleveredAt,
                        Status = item.Status,
                    });
                }
                return maintenanceDTOs;
            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task UpdateMaintenance(int id, MaintenanceDTO newDevice)
        {
            try
            {
                Maintenance maintenance = await _context.MaintenanceDepartment.FirstOrDefaultAsync(m => m.Id == id) 
                    ?? throw new Exception("Can\'t find the target to update");

                if (!string.IsNullOrEmpty(newDevice.CustomerName))
                {
                    maintenance.CustomerName = newDevice.CustomerName;
                }
                if (!string.IsNullOrEmpty(newDevice.DeviceModel))
                {
                    maintenance.DeviceModel = newDevice.DeviceModel;
                }
                if (!string.IsNullOrEmpty(newDevice.CustomerPhoneNumber))
                {
                    maintenance.CustomerPhoneNumber = newDevice.CustomerPhoneNumber;
                }
                if (!string.IsNullOrEmpty(newDevice.IssueType))
                {
                    maintenance.IssueType = newDevice.IssueType;
                }
                if (!string.IsNullOrEmpty(newDevice.CustomerName))
                {
                    maintenance.IssueFees = newDevice.IssueFees;
                }
                if (newDevice.PieceOrginalFee >= 0)
                {
                    maintenance.PieceOrginalFee = newDevice.PieceOrginalFee;
                }
                if (!string.IsNullOrEmpty(newDevice.Notes))
                {
                    maintenance.Notes = newDevice.Notes;
                }

                _context.Update(maintenance);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message); 
            }
        }
    }
}
