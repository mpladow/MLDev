using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLDev.LOTOW.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        // GET: api/<CharactersController>
        private ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService= characterService;
        }
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return _characterService.GetCharacters();
        }

        // GET api/<CharactersController>/5
        [HttpGet("{id}")]
        public Character Get(int id)
        {
            var character = _characterService.GetCharacterById(id);
            return character;
        }

        // POST api/<CharactersController>
        [HttpPost]
        public Character Post([FromBody] Character character)
        {
            var result = _characterService.CreateCharacter(character);
            return result;
        }

        // PUT api/<CharactersController>/5
        [HttpPut("{id}")]
        public Character Put([FromBody] Character character)
        {
            var result = _characterService.UpdateCharacter(character);
            return result;
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var result = _characterService.DeleteCharacter(id);
            return result;
        }
    }
}
