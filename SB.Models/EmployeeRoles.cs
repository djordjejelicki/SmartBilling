using System.ComponentModel.DataAnnotations.Schema;

namespace SB.Models
{
    public class EmployeeRoles
    {
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

        public Employee? Employee { get; set; }
        public Role? Role { get; set; }
    }
}
