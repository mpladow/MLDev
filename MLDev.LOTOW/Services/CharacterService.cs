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

        //private static List<Character> _characterList = new List<Character>() {
        //new Character()
        //{
        //    CharacterId= 1,
        //    Name="Bob",
        //    Cost= 7,
        //    Level= 1,
        //    CharacterStats=new List<CharacterStat>()
        //    {
        //        new CharacterStat()
        //        {
        //            CharacterStatId= 1,
        //            CurrentValue=3,
        //            StatId=1,
        //            InitialValue=3,
        //        }
        //    }
        //}
        //};
        public List<Character> GetCharacters()
        {
            return _dbContext.Characters.ToList();
        }
        public Character CreateCharacter(Character character)
        {
            character.CharacterId = 123;
            _dbContext.Characters.Add(character);
            return character;
        }

        public void DeleteCharacter(int id)
        {
            var entity = _dbContext.Characters.FirstOrDefault(x =>x.CharacterId== id);   
            _dbContext.Characters.Remove(entity);
            _dbContext.SaveChanges();
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
