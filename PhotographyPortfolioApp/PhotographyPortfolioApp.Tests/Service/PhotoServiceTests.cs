using Moq;
using PhotographyPortfolioApp.Service;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using PhotographyPortfolioApp.Shared.Service;
using PhotographyPortfolioApp.Shared.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Tests.Service
{
    public class PhotoServiceTests
    {
        private readonly Mock<IPhotoRepository> _photoRepositoryMock = new Mock<IPhotoRepository>();
        private readonly IPhotoService _service;

        public PhotoServiceTests()
        {
            _service = new PhotoService(_photoRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var photoDto = new PhotoDto()
            {
                Id = 0,
                Description = "",
                Pixels = 0,
                UserId = 0,
                PhotoArray = new byte[0]

            };
            //Act
            await _service.SaveAsync(photoDto);

            //Assert
            _photoRepositoryMock.Verify(x => x.SaveAsync(photoDto), Times.Once);
        }
        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _photoRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _photoRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int photoId)
        {
            //Arrange
            var photoDto = new PhotoDto()
            {
                Id = 0,
                Description = "",
                UserId = 0
            };

            _photoRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(photoId))))
                .ReturnsAsync(photoDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(photoId);

            //Assart
            _photoRepositoryMock.Verify(x => x.GetByIdAsync(photoId), Times.Once);
            Assert.That(userResult == photoDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnDefault(int photoId)
        {
            //Arrange
            var photo = (PhotoDto)default;

            _photoRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(photoId))))
                .ReturnsAsync(photo);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(photoId);

            //Assart
            _photoRepositoryMock.Verify(x => x.GetByIdAsync(photoId), Times.Once);
            Assert.That(userResult == photo);
        }

        [Test]
        public async Task WhenUploadAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var photoDto = new PhotoDto
            {
                Id = 0,
                Description = "",
                UserId = 0
            };
            _photoRepositoryMock.Setup(s => s.SaveAsync(It.Is<PhotoDto>(x => x.Equals(photoDto))))
               .Verifiable();

            //Act
            await _service.SaveAsync(photoDto);

            //Assart
            _photoRepositoryMock.Verify(x => x.SaveAsync(photoDto), Times.Once);
        }
    }
}
