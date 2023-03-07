using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.Data.Data.Entities
{
    [Table("Character", Schema = "LOTOW")]
    public class Character
    {
        public int CharacterId { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Precision(14, 2)]
        public decimal Level { get; set; }
        [Precision(14, 2)]
        public decimal Cost { get; set; }
        public List<CharacterStat> CharacterStats { get; set; } // contains all of the stats,including finite stats

        // TODO: Add List of special rules
    }
}
