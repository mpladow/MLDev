using AutoMapper;
using MLDev.Data.Data.Entities;
using MLDev.Data.DTOs;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services.Interfaces;

namespace MLDev.LOTOW.Services
{
    public class CharacterService : ICharacterService
    {
        private ICharacterRepository _repo;
        private readonly IMapper _mapper;

        public CharacterService(ICharacterRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<CharacterDto> GetCharacters()
        {
            var characters = _repo.GetCharacters();
            var charactersDto = characters.Select(_mapper.Map<Character, CharacterDto>);
            return charactersDto.ToList();
        }
        public CharacterDto? CreateCharacter(CharacterDto character)
        {
            var newCharacter = _mapper.Map<Character>(character);
            var response = _repo.CreateCharacter(newCharacter);
            if (response == null)
            {
                return null;
            }
            character = _mapper.Map<CharacterDto>(response);
            return character;
        }

        public ApiResponseDto DeleteCharacter(int id)
        {
            return _repo.DeleteCharacter(id);
        }

        public CharacterDto? GetCharacterById(int id)
        {
            var character = _repo.GetCharacter(id);
            if (character == null)
            {
                return null;
            }
            var characterDto = _mapper.Map<CharacterDto>(character);
            return characterDto;
        }

        public CharacterDto? UpdateCharacter(CharacterDto character)
        {
            try
            {
            var charToUpdate = _repo.GetCharacter(character.CharacterId);
            _mapper.Map(character, charToUpdate);
            _repo.Save();
            }
            catch
            {
                return null;
            }
            return character;
        }
    }
}
