namespace MLDev.LOTOW.Models
{
    public class CharacterFiniteStatValue
    {
        public int CharacterFiniteStatId { get; set; }
        public Stat Stat { get; set; }
        public Character Character { get; set; }
        public int Value { get; set; }
        public int CurrentValue { get; set; }
        public List<StatModifier> StatModifiers { get; set; }

    }
}