using AutoFixture;
using AutoMapper;
using MLDev.Data.Data.Entities;
using MLDev.Data.DTOs;
using MLDev.LOTOW.Automapper.Mappings;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace MLDev.LOTOW.Tests.Characters
{
    public class CharacterServiceTests
    {
        private IFixture _fixture;
        private IMapper _mapper;

        public CharacterServiceTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappingProfile()));
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async void GetCharacterById_WhenCharacterIdIsGreaterThan1_ShouldReturnCharacter()
        {
            // Arrange
            var repoMock = new Mock<ICharacterRepository>();
            var entity = new Character() { CharacterId = 1, Name = "Test1" };
            var list = new List<Character>
            {
                entity
            };

            repoMock.Setup(x => x.GetCharacter(It.IsAny<int>())).Returns(entity);
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappingProfile()));

            var service = new CharacterService(repoMock.Object, new Mapper(configuration));

            // Act
            var result = service.GetCharacterById(1);

            // Assert

            Assert.NotNull(result);
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

            repoMock.Setup(x => x.GetCharacter(It.IsAny<int>())).Returns(entity);
            var service = new CharacterService(repoMock.Object, _mapper);

            // Act
            var response = service.GetCharacterById(1);

            // Assert

            Assert.NotNull(response);
            Assert.True(entity.CharacterId == response.CharacterId);

        }
        [Fact]
        public async void CreateCharacter_ShouldReturnCharacter_WhenCharacterIsSuccessfullyCreated()
        {
            // Arrange
            var dto = _fixture.Create<CharacterDto>();
            var entity = _mapper.Map<CharacterDto, Character>(dto);
            var repoMock = new Mock<ICharacterRepository>();
            repoMock.Setup(repo => repo.CreateCharacter(It.IsAny<Character>())).Returns(entity);
            var service = new CharacterService(repoMock.Object, _mapper);

            // Act
            var result = service.CreateCharacter(dto);

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(entity, result);
        }
        //public class MockDbSet<TEntity> : Mock<DbSet<TEntity>> where TEntity : class
        //{
        //    public MockDbSet(List<TEntity> dataSource = null)
        //    {
        //        var data = (dataSource ?? new List<TEntity>());
        //        var queryable = data.AsQueryable();

        //        this.As<IQueryable<TEntity>>().Setup(e => e.Provider).Returns(queryable.Provider);
        //        this.As<IQueryable<TEntity>>().Setup(e => e.Expression).Returns(queryable.Expression);
        //        this.As<IQueryable<TEntity>>().Setup(e => e.ElementType).Returns(queryable.ElementType);
        //        this.As<IQueryable<TEntity>>().Setup(e => e.GetEnumerator()).Returns(() => queryable.GetEnumerator());
        //        //Mocking the insertion of entities
        //        this.Setup(_ => _.Add(It.IsAny<TEntity>())).Returns((TEntity arg) => {
        //            data.Add(arg);
        //            return arg;
        //        });

        //        //...the same can be done for other members like Remove
        //    }
        //}
        //[Fact]
    }
}
