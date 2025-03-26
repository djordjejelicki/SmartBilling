using System.ComponentModel.DataAnnotations;

namespace SB.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
        public List<EmployeeRoles>? EmployeeRoles { get; set; }
    }
}
