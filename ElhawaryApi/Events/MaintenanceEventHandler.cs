namespace ElhawaryApi.Events
{
    public class MaintenanceEventHandler
    {
        public void OnMaintenanceCreated(object sender, MaintenanceEventArgs e)
        {
            Console.WriteLine($"Event Triggered : {e.Maintenance.CustomerName}");
        }
    }
}
