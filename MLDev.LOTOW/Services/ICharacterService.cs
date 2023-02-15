using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Services
{
    public interface ICharacterService
    {
        List<Character> GetCharacters();
        Character GetCharacterById(int id);
        Character CreateCharacter(Character character);
        Character UpdateCharacter(Character character);
        bool DeleteCharacter(int id);
    }
}
