namespace HA_Ossooll.Data.Models
{
    public class OperationType
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Operation> Operations { get; set; } = new List<Operation>();
    }
}