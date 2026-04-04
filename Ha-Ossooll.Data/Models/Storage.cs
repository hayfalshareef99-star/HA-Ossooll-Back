namespace HA_Ossooll.Data.Models
{
    public class Storage
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
    }
}