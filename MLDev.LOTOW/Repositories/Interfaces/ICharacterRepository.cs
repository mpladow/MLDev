using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        List<Character> Get();
        Character Get(int id);
        Character Create(Character character);
        Character Update(Character character);
        bool Delete(int id);
    }
}
