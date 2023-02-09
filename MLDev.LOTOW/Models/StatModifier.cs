using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.Models
{

    public class StatModifier
    {
        public int StatModifierId { get; set; }
        public Stat StatModified { get; set; }
        public int Value { get; set; }
        public string SourceDescription { get; set; }
    }
}
