namespace HA_Ossooll.Data.DTOs
{
    public class MaintenanceDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string StorageName { get; set; } = string.Empty;
        public string ProductTypeName { get; set; } = string.Empty;
    }
}