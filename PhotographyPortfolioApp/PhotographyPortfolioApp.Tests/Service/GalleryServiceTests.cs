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
    public class GalleryServiceTests
    {
        private readonly Mock<IGalleryRepository> _galleryRepositoryMock = new Mock<IGalleryRepository>();
        private readonly IGalleryService _service;

        public GalleryServiceTests()
        {
            _service = new GalleryService(_galleryRepositoryMock.Object);
        }
       
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var galleryDto = new GalleryDto()
            {
                Id = 0,
                Name = "Pug",
                Description = "",
                UserId = 0
            };
            //Act
            await _service.SaveAsync(galleryDto);

            //Assert
            _galleryRepositoryMock.Verify(x => x.SaveAsync(galleryDto), Times.Once);
        }
        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _galleryRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _galleryRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int galleryId)
        {
            //Arrange
            var galleryDto = new GalleryDto()
            {
                Id = 0,
                Name = "Pug",
                Description = "",
                UserId = 0
            };

            _galleryRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(galleryId))))
                .ReturnsAsync(galleryDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(galleryId);

            //Assart
            _galleryRepositoryMock.Verify(x => x.GetByIdAsync(galleryId), Times.Once);
            Assert.That(userResult == galleryDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnDefault(int galleryId)
        {
            //Arrange
            var gallery = (GalleryDto)default;

            _galleryRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(galleryId))))
                .ReturnsAsync(gallery);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(galleryId);

            //Assart
            _galleryRepositoryMock.Verify(x => x.GetByIdAsync(galleryId), Times.Once);
            Assert.That(userResult == gallery);
        }

        [Test]
        public async Task WhenUploadAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var galleryDto = new GalleryDto
            {
                Id = 0,
                Name = "Pug",
                Description = "",
                UserId = 0
            };
            _galleryRepositoryMock.Setup(s => s.SaveAsync(It.Is<GalleryDto>(x => x.Equals(galleryDto))))
               .Verifiable();

            //Act
            await _service.SaveAsync(galleryDto);

            //Assart
            _galleryRepositoryMock.Verify(x => x.SaveAsync(galleryDto), Times.Once);
        }

    }
    
}
