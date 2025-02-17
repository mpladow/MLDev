﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLDev.Data.DTOs;
using MLDev.LOTOW.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLDev.LOTOW.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        // GET: api/<CharactersController>
        public ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpGet]
        public IEnumerable<CharacterDto> Get()
        {
            var characters = _characterService.GetCharacters();
            return characters;
        }

        // GET api/<CharactersController>/5
        [HttpGet("{id}")]
        public CharacterDto Get(int id)
        {
            var response = _characterService.GetCharacterById(id);
            return response;
        }

        // POST api/<CharactersController>
        [HttpPost]
        public CharacterDto Post([FromBody] CharacterDto character)
        {
            var result = _characterService.CreateCharacter(character);
            return result;
        }

        // PUT api/<CharactersController>/5
        [HttpPut("{id}")]
        public CharacterDto Put([FromBody] CharacterDto character)
        {
            var result = _characterService.UpdateCharacter(character);
            return result;
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        public ApiResponseDto Delete(int id)
        {
            var result = _characterService.DeleteCharacter(id);
            return result;
        }
    }
}
