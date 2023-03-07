using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.Data.Data.Entities
{
    [Table("StatModifier", Schema = "LOTOW")]
    public class StatModifier
    {
        public int StatModifierId { get; set; }
        public int Value { get; set; }
        public string SourceDescription { get; set; }
    }
}
