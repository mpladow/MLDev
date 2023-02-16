using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.Models
{
    [Table("CharacterStat", Schema = "LOTOW")]
    public class CharacterStat
    {
        public int CharacterStatId { get; set; }
        public int StatId { get; set; }
        public int CharacterId { get; set; }
        public Stat Stat { get; set; }
        public Character Character { get; set; }
        public int InitialValue { get; set; }
        public int CurrentValue { get; set; }
        public List<StatModifier> StatModifiers { get; set; }
    }
}