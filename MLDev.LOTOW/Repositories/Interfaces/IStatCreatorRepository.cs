using MLDev.Data.Data.Entities;
using MLDev.Data.DTOs;

namespace MLDev.LOTOW.Repositories.Interfaces
{
    public interface IStatCreatorRepository
    {
        List<Stat> GetStats();
        Stat GetStatById(int id);
        Stat Create(Stat stat);
        ApiResponseDto Delete(int id);
        ApiResponseDto Save();
    }
}
