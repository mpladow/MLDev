using Microsoft.EntityFrameworkCore;
using MLDev.LOTOW.Data;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace MLDev.LOTOW.Tests.Characters
{
    public class CharacterServiceTests
    {
        private readonly CharacterService _characterService;
        private readonly Mock<LOTOWDbContext> _dbContextMock = new Mock<LOTOWDbContext>();

        public CharacterServiceTests()
        {
            _characterService = new CharacterService(_dbContextMock.Object);
        }
        [Fact]
        public async void GetCharacters_ShouldReturnNull_WhenNoCharactersExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            var newCharacter = new Character();
            newCharacter.Cost = 1;
            newCharacter.Level = 1;
            _dbContextMock.Setup(x => x.Characters).Returns(new Mock<DbSet<Character>>().Object);


            // Act
            var results = _characterService.GetCharacters();

            // Assert
            Assert.Empty(results);
        }
    }
}
