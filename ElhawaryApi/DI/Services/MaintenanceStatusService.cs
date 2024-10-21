
namespace ElhawaryApi.DI.Services
{
    public class MaintenanceStatusService(AppDbcontext context) : IMaintenanceStatusService
    {
        private readonly AppDbcontext _context = context;

        public async Task<MaintenanceStatus> AddNewStatus(MaintenanceStatus status)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(status);

                await _context.AddAsync(status);
                await _context.SaveChangesAsync();
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
