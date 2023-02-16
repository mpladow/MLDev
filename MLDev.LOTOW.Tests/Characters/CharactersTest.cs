using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLDev.LOTOW.Controllers;
using MLDev.LOTOW.Data;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services;
using MLDev.LOTOW.Services.Interfaces;
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
        [Fact]
        public async void GetCharacterById_ShouldReturnCharacterWhenIdGreaterThanZero()
        {
            // Arrange
            var repoMock = new Mock<ICharacterRepository>();
            var entity = new Character() { CharacterId = 1, Name = "Test1" };
            var list = new List<Character>
            {
                entity
            };

            repoMock.Setup(x => x.Get(It.IsAny<int>())).Returns(entity);
            var service = new CharacterService(repoMock.Object);

            // Act
            var result = service.GetCharacterById(0);

            // Assert

            Assert.Null(result);
        }
        [Fact]
        public async void GetCharacterById_ShouldReturnCharacter_WhenIdExists()
        {
            // Arrange
            var repoMock = new Mock<ICharacterRepository>();
            var entity = new Character() { CharacterId = 1, Name = "Test1" };
            var list = new List<Character>
            {
                entity
            };

            repoMock.Setup(x => x.Get(It.IsAny<int>())).Returns(entity);
            var service = new CharacterService(repoMock.Object);

            // Act
            var response = service.GetCharacterById(1);

            // Assert

            Assert.NotNull(response);
            Assert.Equal(entity, response);
            Assert.True(entity.CharacterId == response.CharacterId);

        }
        [Fact]
        public async void CreateCharacter_ShouldReturnCharacter_WhenCharacterIsSuccessfullyCreated()
        {
            //// Arrange
            //var entity = new Character() { Name= "Test name",Level=3, Cost= 7 };

            //csMock.Setup(repo => repo.CreateCharacter(It.IsAny<Character>())).Returns(entity);
            //var controller = new CharactersController(csMock.Object);

            //// Act
            //var result = controller.Post(entity);

            //// Assert

            //Assert.NotNull(result); 
            //Assert.Equal(entity, result);
        }

        
    }
}
