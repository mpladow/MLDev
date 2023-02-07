namespace MLDev.LOTOW.Models
{
    public class Stat
    {
        public int StatId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public StatModifier[] Modifiers { get; set; }
    }
}
