namespace MLDev.LOTOW.Models
{
    public class CharacterStat
    {
        public int CharacterStatId { get; set; }
        public Stat Stat { get; set; }
        public Character Character { get; set; }
        public int Value { get; set; }
        public List<StatModifier> StatModifiers { get; set; }
    }
}