using System.ComponentModel.DataAnnotations.Schema;

namespace HA_Ossooll.Data.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public long StorageId { get; set; }

        [ForeignKey(nameof(StorageId))]
        public Storage? Storage { get; set; }

        public long ProductTypeId { get; set; }

        [ForeignKey(nameof(ProductTypeId))]
        public ProductType? ProductType { get; set; }
    }
}