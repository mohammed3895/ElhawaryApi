namespace ElhawaryApi.Models.Domain
{
    public class Maintenance
    {        
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string DeviceModel { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public string IssueType { get; set; } = string.Empty;
        public double IssueFees { get; set; }
        public double? PieceOrginalFee { get; set; }
        public DateTime RecievedAt { get; set; } = DateTime.Now;
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public byte MaintenanceType { get; set; }
        public DateTime? DeleveredAt { get; set; } = null;
    }
}
