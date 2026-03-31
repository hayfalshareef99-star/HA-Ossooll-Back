namespace HA_Ossooll.Data.Models
{
    internal class Operations
    {
        public class Operation
        {
            public long Id { get; set; }

            public int Quantity { get; set; }

            public DateTime Date { get; set; }

            public string State { get; set; } = string.Empty;

            public string Type { get; set; } = string.Empty;
        }
    }
}

