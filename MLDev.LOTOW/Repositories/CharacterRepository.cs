using Microsoft.EntityFrameworkCore;
using MLDev.LOTOW.Data;
using MLDev.LOTOW.Data.Entities;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Repositories.Interfaces;

namespace MLDev.LOTOW.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly LOTOWDbContext _dbContext;
        public CharacterRepository(LOTOWDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Character> GetCharacters()
        {
            return _dbContext.Characters.ToList();
        }
        public Character CreateCharacter(Character character)
        {
            var result = _dbContext.Characters.Add(character);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public ResponseDto DeleteCharacter(int id)
        {
            var response = new ResponseDto();
            var entity = _dbContext.Characters.FirstOrDefault(x => x.CharacterId == id);
            if (entity == null)
            {
                response.Success = false;
                response.ErrorMessage = "No Character Found";
            }
            _dbContext.Characters.Remove(entity);
            _dbContext.SaveChanges();
            response.Success = true;
            return response;
        }

        public Character GetCharacter(int id)
        {
            var entity = _dbContext.Characters.FirstOrDefault(x => x.CharacterId == id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public ResponseDto Save()
        {
            var response = new ResponseDto();
            try
            {
                _dbContext.SaveChanges();
                response.Success = true;
            }
            catch (DbUpdateException e)
            {
                response.Success &= false;
                response.ErrorMessage = e.Message;
                // handle the update exception
            }
            return response;
        }
    }
}
