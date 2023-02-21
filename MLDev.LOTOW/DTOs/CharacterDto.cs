using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using MLDev.LOTOW.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.DTOs
{
    public class CharacterDto
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        [Precision(14, 2)]
        public decimal Level { get; set; }
        [Precision(14, 2)]
        public decimal Cost { get; set; }
        public List<CharacterStatDto> CharacterStats { get; set; } // contains all of the stats,including finite stats
                                                                   // TODO: Add List of special rules
    }
}