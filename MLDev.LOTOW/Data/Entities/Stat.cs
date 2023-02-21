using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.Data.Entities
{
    [Table("Stat", Schema = "LOTOW")]
    public class Stat
    {
        public int StatId { get; set; }
        public int Order { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        public bool IsFinite { get; set; }// if this stat has a set amount
        public bool IsDeleted { get; set; }
    }
}
