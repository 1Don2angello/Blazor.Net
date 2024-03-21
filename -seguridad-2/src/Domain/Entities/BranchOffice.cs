using Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class BranchOffice : AuditableBaseEntry
    {
        [Key]
        [Column("pkBranchOffice")]
        public int PkBranchOffice { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool Active { get; set; }
        public string IdBranchPayment { get; set; }
        public string UserPayment { get; set; }
        public string PwdPayment { get; set; }
        public string Longuitude { get; set; }
        public string Lactitude { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Zone { get; set; }
        [Column("isBOOperation")]
        public bool IsBOOperation { get; set; }

    }
}
