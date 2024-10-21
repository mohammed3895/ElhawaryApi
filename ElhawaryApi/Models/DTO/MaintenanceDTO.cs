using ElhawaryApi.Models.Domain;

namespace ElhawaryApi.Models.DTO
{
    public class MaintenanceDTO
    {
        public MaintenanceDTO()
        {
        }

        public MaintenanceDTO(int id, string customerName, string deviceModel, string customerPhoneNumber, string issueType, double issueFees, double? pieceOrginalFee, DateTime recievedAt, string? notes, string? status, byte maintenanceType, DateTime? deleveredAt)
        {
            Id = id;
            CustomerName = customerName;
            DeviceModel = deviceModel;
            CustomerPhoneNumber = customerPhoneNumber;
            IssueType = issueType;
            IssueFees = issueFees;
            PieceOrginalFee = pieceOrginalFee;
            RecievedAt = recievedAt;
            Notes = notes;
            Status = status;
            MaintenanceType = maintenanceType;
            DeleveredAt = deleveredAt;
        }

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
