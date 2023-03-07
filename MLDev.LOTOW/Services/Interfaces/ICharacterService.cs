using MLDev.Data.DTOs;
using MLDev.LOTOW.DTOs;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface ICharacterService
    {
        List<CharacterDto> GetCharacters();
        CharacterDto GetCharacterById(int id);
        CharacterDto CreateCharacter(CharacterDto character);
        CharacterDto UpdateCharacter(CharacterDto character);
        ApiResponseDto DeleteCharacter(int id);
    }
}
