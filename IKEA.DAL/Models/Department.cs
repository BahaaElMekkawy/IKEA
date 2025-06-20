

using Employe = IKEA.DAL.Models.Employee.Employee; // Solve the Conflict between name space and classe.

namespace IKEA.DAL.Models
{
    public class Department : BaseEntity
    {
        public string Name  { get; set; }
        public string Code{ get; set; }
        public string? Description{ get; set; }
        public ICollection<Employe> Employees { get; set; } = new HashSet<Employe>();


    }
}
