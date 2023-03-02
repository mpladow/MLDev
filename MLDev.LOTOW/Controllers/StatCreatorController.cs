using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Services.Interfaces;

namespace MLDev.LOTOW.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class StatCreatorController : ControllerBase
    {
        private IStatCreatorService _statCreatorService;

        public StatCreatorController(IStatCreatorService statCreatorService)
        {
            _statCreatorService = statCreatorService;
        }

        [HttpGet]
        public List<StatDto> Index()
        {
            return _statCreatorService.GetStats().ToList();
        }

        // GET: StatCreator/Details/5
        [HttpGet("{id}")]
        public StatDto Details(int id)
        {
            return _statCreatorService.GetStatById(id);
        }

        // POST: StatCreator/Create
        [HttpPost]
        public StatDto? Post(StatDto stat)
        {
            try
            {
                return _statCreatorService.CreateStat(stat);
                
            }
            catch
            {
                return null;
            }
        }

        // GET: StatCreator/Edit/5
        [HttpPut("{id}")]
        public StatDto Put([FromBody] StatDto character)
        {
            var result = _statCreatorService.UpdateStat(character);
            return result;
        }

        // DELETE api/<StatCreator>/5
        [HttpDelete("{id}")]
        public ApiResponseDto Delete(int id)
        {
            var result = _statCreatorService.DeleteStat(id);
            return result;
        }
    }
}
