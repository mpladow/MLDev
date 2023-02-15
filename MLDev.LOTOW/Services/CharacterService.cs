using MLDev.LOTOW.Data;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly LOTOWDbContext _dbContext;

        public CharacterService(LOTOWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Character> GetCharacters()
        {
            return _dbContext.Characters.ToList();
        }
        public Character CreateCharacter(Character character)
        {
            character.CharacterId = 123;
            var result = _dbContext.Characters.Add(character);
            return result.Entity;
        }

        public bool DeleteCharacter(int id)
        {
            var entity = _dbContext.Characters.FirstOrDefault(x =>x.CharacterId== id);   
            if (entity == null)
            {
                return false;
            }
            _dbContext.Characters.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public Character GetCharacterById(int id)
        {
            var entity = _dbContext.Characters.FirstOrDefault(x => x.CharacterId == id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }



        public Character UpdateCharacter(Character character)
        {
            var entity = _dbContext.Characters.FirstOrDefault(x => x.CharacterId == character.CharacterId);
            if (entity == null)
            {
                return null;
            }
            entity.Name = character.Name;
            entity.Level = character.Level;
            entity.Cost = character.Cost;
            entity.CharacterStats = character.CharacterStats;

            return entity;
        }
    }
}
