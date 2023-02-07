namespace MLDev.LOTOW.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Level { get; set; }
        public decimal Cost { get; set; }
        public int StartingFame { get; set; }
        public int CurrentFame { get; set; }
        public int StartingFortune { get; set; }
        public int CurrentFortune { get; set; }
    }
}
