using System.ComponentModel.DataAnnotations.Schema;

namespace HA_Ossooll.Data.Models
{
    public class Employee
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public long DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        public long? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Employee? Manager { get; set; }

        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
    }
}