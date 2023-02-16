using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLDev.LOTOW.Controllers;
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
        private readonly Mock<ICharacterService> csMock;

        public CharacterServiceTests()
        {
            csMock = new Mock<ICharacterService>();
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)] 
        public async void GetCharacterById_ShouldReturnCharacterWhenIdGreaterThanZero(int characterId)
        {
            // Arrange
            var entity = new Character() { CharacterId = 1, Name = "Test1" };
            var list = new List<Character>
            {
                entity
            };

            csMock.Setup(x => x.GetCharacterById(characterId)).Returns(true);
            var controller = new CharactersController(csMock.Object);

            // Act

            var response = controller.Get(characterId);

            // Assert

            Assert.Null(response);
        }
        [Fact]
        public async void GetCharacterById_ShouldReturnCharacter_WhenIdExists()
        {
            // Arrange
            var characterId = 1;
            var entity = new Character() { CharacterId = 1, Name = "Test1" };

            var list = new List<Character>
            {
                entity
            };

            csMock.Setup(x => x.GetCharacterById(characterId)).Returns(entity);
            var controller = new CharactersController(csMock.Object);


            // Act
            var response = controller.Get(1);

            // Assert

            Assert.NotNull(response);
            Assert.Equal(entity, response);
            Assert.True(entity.CharacterId == response.CharacterId);
            csMock.Verify(m=>m.CreateCharacter(entity), Times.Once);

        }
        [Fact]
        public async void CreateCharacter_ShouldReturnCharacter_WhenCharacterIsSuccessfullyCreated()
        {
            // Arrange
            var entity = new Character() { Name= "Test name",Level=3, Cost= 7 };

            csMock.Setup(repo => repo.CreateCharacter(It.IsAny<Character>())).Returns(entity);
            var controller = new CharactersController(csMock.Object);

            // Act
            var result = controller.Post(entity);

            // Assert

            Assert.NotNull(result); 
            Assert.Equal(entity, result);
        }

        
    }
}
