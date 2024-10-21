namespace ElhawaryApi.Models.Domain
{
    public class MaintenanceStatus
    {
        public int Id { get; set; }
        public int MaintenanceStatusTypeId { get; set; }

        [ForeignKey(nameof(MaintenanceStatusTypeId))]
        public virtual MaintenanceStatusType MaintenanceStatusType { get; set; }

        public int? TechnicanId { get; set; }
        [ForeignKey("TechnicanId")]
        public virtual Technicans? Technican { get; set; }

        public int MaintenanceId { get; set; }
        [ForeignKey(nameof(MaintenanceId))]
        public virtual ICollection<Maintenance>? Maintenances { get; set; }
    }
}
