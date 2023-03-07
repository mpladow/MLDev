using MLDev.Data.DTOs;
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
