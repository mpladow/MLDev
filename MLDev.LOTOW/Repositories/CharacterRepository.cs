using Microsoft.EntityFrameworkCore;
using MLDev.LOTOW.Data;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Repositories.Interfaces;

namespace MLDev.LOTOW.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly LOTOWDbContext _dbContext;
        public CharacterRepository(LOTOWDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public List<Character> Get()
        {
            return _dbContext.Characters.ToList();
        }
        public Character Create(Character character)
        {
            var result = _dbContext.Characters.Add(character);
            return result.Entity;
        }

        public bool Delete(int id)
        {
            var entity = _dbContext.Characters.FirstOrDefault(x => x.CharacterId == id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.Characters.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public Character Get(int id)
        {
            var entity = _dbContext.Characters.FirstOrDefault(x => x.CharacterId == id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }



        public Character Update(Character character)
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
