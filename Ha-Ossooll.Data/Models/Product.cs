namespace HA_Ossooll.Data.Models
{
        public class Product

        {
            public long Id { get; set; } // وضعناه ببلك لكي يمكن لاي كود خارج الكلاس الوصول اليه ويمكن قراءة وتعديل والفراغ 
            public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
    }



