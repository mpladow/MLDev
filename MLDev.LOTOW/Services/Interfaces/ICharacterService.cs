using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface ICharacterService
    {
        List<Character> GetCharacters();
        Character GetCharacterById(int id);
        Character CreateCharacter(Character character);
        Character UpdateCharacter(Character character);
        void DeleteCharacter(int id);
    }
}
