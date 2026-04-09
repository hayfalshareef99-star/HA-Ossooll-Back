using System.ComponentModel.DataAnnotations.Schema;

namespace HA_Ossooll.Data.Models
{
    public class Maintenance
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Cost { get; set; }

        public long StorageId { get; set; }

        [ForeignKey(nameof(StorageId))]
        public Storage? Storage { get; set; }
    }
}