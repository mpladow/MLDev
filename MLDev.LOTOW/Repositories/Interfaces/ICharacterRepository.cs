using MLDev.LOTOW.Data.Entities;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        List<Character> GetCharacters();
        Character GetCharacter(int id);
        Character CreateCharacter(Character character);
        ResponseDto DeleteCharacter(int id);
        ResponseDto Save();

    }
}
