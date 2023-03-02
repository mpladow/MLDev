using MLDev.LOTOW.Data.Entities;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface IStatCreatorService
    {
        List<StatDto> GetStats();
        StatDto GetStatById(int id);
        StatDto UpdateStat(StatDto stat);
        StatDto CreateStat(StatDto stat);
        ApiResponseDto DeleteStat(int id);

    }
}
