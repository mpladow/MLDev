using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface IStatCreatorService
    {
        List<Stat> GetStats();
        Stat GetStatById(int id);
        Stat UpdateStat(Stat stat);
        Stat CreateStat(Stat stat);
        void DeleteStat(int id);

    }
}
