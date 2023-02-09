using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Services
{
    public class CharacterService : ICharacterService
    {
        public CharacterService()
        {

        }
        private static List<Character> _characterList = new List<Character>() {
        new Character()
        {
            CharacterId= 1,
            Name="Bob",
            Cost= 7,
            Level= 1,
            CharacterStats=new List<CharacterStat>()
            {
                new CharacterStat()
                {
                    CharacterStatId= 1,
                    CurrentValue=3,
                    StatId=1,
                    InitialValue=3,
                }
            }
        }
        };
        public List<Character> GetCharacters()
        {
            return _characterList;
        }
        public Character CreateCharacter(Character character)
        {
            character.CharacterId = 123;
            _characterList.Add(character);
            return character;
        }

        public void DeleteCharacter(int id)
        {
            _characterList.RemoveAt(id);
        }

        public Character GetCharacterById(int id)
        {
            var entity = _characterList.Find(x => x.CharacterId == id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }



        public Character UpdateCharacter(Character character)
        {
            var entity = _characterList.Find(x => x.CharacterId == character.CharacterId);
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
