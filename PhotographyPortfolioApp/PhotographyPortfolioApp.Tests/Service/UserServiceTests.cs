using Moq;
using PhotographyPortfolioApp.Service;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using PhotographyPortfolioApp.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Tests.Service
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();

        private readonly IUserService _service;

        public UserServiceTests()
        {
            _service = new UserService(_userRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithVallidData_ThenSaveAsync()
        {
            //Arrange
            var userDto = new UserDto()
            {
                Id = 0,
                Username = "Minnie",
                Password = "W#N*79HJ",
                FirstName = "Walther",
                LastName = "Jones",
                Age = 0,
                RoleId = 0
            };

            //Act
            await _service.SaveAsync(userDto);

            //Assert
            _userRepositoryMock.Verify(x => x.SaveAsync(userDto), Times.Once);
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _userRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCalldeleteAsyncInRepository(int id)
        {
            //Arrange


            //Act
            await _service.DeleteAsync(id);

            //Assart
            _userRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int userId)
        {
            //Arrange
            var userDto = new UserDto()
            {
                Id = 0,
                Username = "Minnie",
                Password = "W#N*79HJ",
                FirstName = "Walther",
                LastName = "Jones",
                Age = 0,
                RoleId = 0
            };

            _userRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(userId))))
                .ReturnsAsync(userDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(userId);

            //Assart
            _userRepositoryMock.Verify(x => x.GetByIdAsync(userId), Times.Once);
            Assert.That(userResult == userDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnDefault(int userId)
        {
            //Arrange
            var user = (UserDto)default;

            _userRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(userId))))
                .ReturnsAsync(user);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(userId);

            //Assart
            _userRepositoryMock.Verify(x => x.GetByIdAsync(userId), Times.Once);
            Assert.That(userResult == user);
        }

        [Test]
        public async Task WhenUploadAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var userDto = new UserDto
            {
                Id = 0,
                Username = "Minnie",
                Password = "W#N*79HJ",
                FirstName = "Walther",
                LastName = "Jones",
                Age = 0,
                RoleId = 0
            };
            _userRepositoryMock.Setup(s => s.SaveAsync(It.Is<UserDto>(x => x.Equals(userDto))))
               .Verifiable();

            //Act
            await _service.SaveAsync(userDto);

            //Assart
            _userRepositoryMock.Verify(x => x.SaveAsync(userDto), Times.Once);
        }
    }
}
