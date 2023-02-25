using MLDev.LOTOW.Data.Entities;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Repositories.Interfaces
{
    public interface IStatCreatorRepository
    {
        List<Stat> GetStats();
        Stat GetStatById(int id);
        Stat Create(Stat stat);
        ResponseDto Delete(int id);
        ResponseDto Save();
    }
}
