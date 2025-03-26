using System.ComponentModel.DataAnnotations;

namespace SB.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public List<Bill>? Bills { get; set; }
        public List<EmployeeRoles>? EmployeeRoles { get; set; }
        
    }
}
