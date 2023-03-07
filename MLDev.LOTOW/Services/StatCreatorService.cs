using AutoMapper;
using MLDev.Data.DTOs;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services.Interfaces;

namespace MLDev.LOTOW.Services
{
    public class StatCreatorService : IStatCreatorService
    {
        private readonly IStatCreatorRepository _statCreatorRepository;
        private readonly IMapper _mapper;

        public StatCreatorService(IStatCreatorRepository statCreatorRepository, IMapper mapper)
        {
            _statCreatorRepository = statCreatorRepository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public StatDto CreateStat(StatDto stat)
        {
            throw new NotImplementedException();
        }

        public ApiResponseDto DeleteStat(int id)
        {
            return _statCreatorRepository.Delete(id);
        }

        public StatDto GetStatById(int id)
        {
            throw new NotImplementedException();
        }

        public List<StatDto> GetStats()
        {
            throw new NotImplementedException();
        }

        public StatDto UpdateStat(StatDto stat)
        {
            var statToUpdate = _statCreatorRepository.GetStatById(stat.StatId);
            if (statToUpdate != null)
            {
                _mapper.Map(stat,statToUpdate);
                _statCreatorRepository.Save();
            }
            return stat;
        }
    }
}
