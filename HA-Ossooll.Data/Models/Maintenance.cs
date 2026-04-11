using System.ComponentModel.DataAnnotations.Schema;

namespace HA_Ossooll.Data.Models
{
    public class Maintenance
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Cost { get; set; }

        public long ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
    }
}