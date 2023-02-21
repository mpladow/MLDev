using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.DTOs
{
    public class CharacterStatDto
    {
        public int CharacterStatId { get; set; }
        public int InitialValue { get; set; }
        public int CurrentValue { get; set; }
        public List<StatModifierDto> StatModifiers { get; set; }
    }
}
