using AutoMapper;
using MLDev.LOTOW.Data;
using MLDev.LOTOW.Data.Entities;
using MLDev.LOTOW.Repositories.Interfaces;

namespace MLDev.LOTOW.Repositories
{
    public class StatCreatorRepository : IStatCreatorRepository
    {
        private LOTOWDbContext _dbContext;
        private readonly IMapper _mapper;

        public StatCreatorRepository(LOTOWDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Stat CreateStat(Stat stat)
        {
            _dbContext.Add(stat);
            _dbContext.SaveChanges();
            return stat;
        }

        public void DeleteStat(int id)
        {
            var statToDelete = _dbContext.Stats.FirstOrDefault(x => x.StatId == id);
            if (statToDelete != null)
            {
                _dbContext.Stats.Remove(statToDelete);
                _dbContext.SaveChanges();
            }
        }

        public Stat? GetStatById(int id)
        {
            return _dbContext.Stats.FirstOrDefault(x => x.StatId == id);
        }

        public List<Stat> GetStats()
        {
            return _dbContext.Stats.Where(x => !x.IsDeleted).ToList();
        }

        public Stat? UpdateStat(int id, Stat stat)
        {
            var statToUpdate = _dbContext.Stats.FirstOrDefault(x => x.StatId == id);
            if (statToUpdate != null)
            {
                statToUpdate = _mapper.Map<Stat>(stat);
                _dbContext.Stats.Update(statToUpdate);
            }
            return statToUpdate;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
