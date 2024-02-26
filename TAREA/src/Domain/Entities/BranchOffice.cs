using Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class BranchOffice : AuditableBaseEntry
    {
        [Table("Usuers")]
        public class Usuers
        {
            [Key]
            public int Id2 { get; set; }
            public string Name2 { get; set; }
            public string Apellido2 { get; set; }

        }
    }
}
