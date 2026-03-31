namespace HA_Ossooll.Data.Models
{
    public class Maintenance
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Cost { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!; 
    }
}