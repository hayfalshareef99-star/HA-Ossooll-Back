namespace HA_Ossooll.Data.Models
{
    public class Operations
    {
        public class Operation
        {
            public long Id { get; set; }

            public int Quantity { get; set; }

            public DateTime Date { get; set; }

            public enum State { get; set; } = string.Empty;//باقي ماكملنا تعريف الحالات

            public string Type { get; set; } = string.Empty;
        }
    }
}

