namespace ElhawaryApi.Events
{
    public class MaintenanceEventArgs(Maintenance maintenance) : EventArgs
    {
        public Maintenance Maintenance { get; } = maintenance;
    }
}
