using MLDev.LOTOW.Data.Entities;

namespace MLDev.LOTOW.Repositories.Interfaces
{
    public interface IStatCreatorRepository
    {
        List<Stat> GetStats();
        Stat GetStatById(int id);
        Stat CreateStat(Stat stat);
        Stat UpdateStat(int id, Stat stat);
        void DeleteStat(int id);
        void Save();
    }
}
