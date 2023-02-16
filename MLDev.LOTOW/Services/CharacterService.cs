using MLDev.LOTOW.Data;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Repositories;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services.Interfaces;

namespace MLDev.LOTOW.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public List<Character> GetCharacters()
        {
            return _characterRepository.Get();
        }
        public Character CreateCharacter(Character character)
        {
            return _characterRepository.Create(character);
        }

        public bool DeleteCharacter(int id)
        {
            return _characterRepository.Delete(id);
        }

        public Character GetCharacterById(int id)
        {
            return _characterRepository.Get(id);
        }


        public Character UpdateCharacter(Character character)
        {
            return _characterRepository.Update(character);
        }
    }
}
