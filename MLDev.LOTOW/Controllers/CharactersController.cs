using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLDev.LOTOW.Controllers
{
    [Authorize]
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CharactersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CharactersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
