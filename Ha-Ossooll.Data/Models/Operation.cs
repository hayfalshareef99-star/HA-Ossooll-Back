using System.ComponentModel.DataAnnotations.Schema;
using HA_Ossooll.Data.Enums;

namespace HA_Ossooll.Data.Models
{
    public class Operation
    {
        public long Id { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public StateEnum State { get; set; }

        public long OperationTypeId { get; set; }

        [ForeignKey(nameof(OperationTypeId))]
        public OperationType? OperationType { get; set; }
    }
}