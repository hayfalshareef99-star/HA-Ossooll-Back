using System.ComponentModel.DataAnnotations.Schema;

namespace HA_Ossooll.Data.Models
{
    public class Department
    {
        public long Id { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public long? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Employee? Manager { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}