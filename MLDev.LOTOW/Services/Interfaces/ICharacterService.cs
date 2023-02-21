using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface ICharacterService
    {
        List<CharacterDto> GetCharacters();
        CharacterDto GetCharacterById(int id);
        CharacterDto CreateCharacter(CharacterDto character);
        CharacterDto UpdateCharacter(CharacterDto character);
        ResponseDto DeleteCharacter(int id);
    }
}
