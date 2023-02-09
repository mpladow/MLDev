using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.Models
{
    
    public class Character
    {
        public int CharacterId { get; set; }
        [Column(TypeName ="varchar(200)")]
        public string Name { get; set; }
        [Precision(14, 2)]
        public decimal Level { get; set; }
        [Precision(14, 2)]
        public decimal Cost { get; set; }
        public List<CharacterStat> Stats { get; set; } // contains the actual stats, including the finite ones default value
        public List<CharacterFiniteStatValue> FiniteStatValues { get; set; }// contains the current values of any finite values

        // TODO: Add List of special rules
    }
}
