using Moq;
using PhotographyPortfolioApp.Service;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using PhotographyPortfolioApp.Shared.Service;

namespace PhotographyPortfolioApp.Tests.Service
{
    public class PhotoGalleryServiceTests
    {
        private readonly Mock<IPhotoGalleryRepository> _photoGalleryRepositoryMock = new Mock<IPhotoGalleryRepository>();
        private readonly IPhotoGalleryService _service;

        public PhotoGalleryServiceTests()
        {
            _service = new PhotoGalleryService(_photoGalleryRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var photoGalleryDto = new PhotoGalleryDto()
            {
                Id = 0,
                PhotoId = 0,
                GalleryId = 0
            };
            //Act
            await _service.SaveAsync(photoGalleryDto);

            //Assert
            _photoGalleryRepositoryMock.Verify(x => x.SaveAsync(photoGalleryDto), Times.Once);
        }
        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _photoGalleryRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _photoGalleryRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int photoGalleryId)
        {
            //Arrange
            var photoGalleryDto = new PhotoGalleryDto()
            {
                Id = 0,
                PhotoId = 0,
                GalleryId = 0
            };

            _photoGalleryRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(photoGalleryId))))
                .ReturnsAsync(photoGalleryDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(photoGalleryId);

            //Assert
            _photoGalleryRepositoryMock.Verify(x => x.GetByIdAsync(photoGalleryId), Times.Once);
            Assert.That(userResult == photoGalleryDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnDefault(int photoGalleryId)
        {
            //Arrange
            var photoGallery = (PhotoGalleryDto)default;

            _photoGalleryRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(photoGalleryId))))
                .ReturnsAsync(photoGallery);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(photoGalleryId);

            //Assart
            _photoGalleryRepositoryMock.Verify(x => x.GetByIdAsync(photoGalleryId), Times.Once);
            Assert.That(userResult == photoGallery);
        }

        [Test]
        public async Task WhenUploadAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var photoGalleryDto = new PhotoGalleryDto
            {
                Id = 0,
                PhotoId = 0,
                GalleryId = 0
            };
            _photoGalleryRepositoryMock.Setup(s => s.SaveAsync(It.Is<PhotoGalleryDto>(x => x.Equals(photoGalleryDto))))
               .Verifiable();

            //Act
            await _service.SaveAsync(photoGalleryDto);

            //Assart
            _photoGalleryRepositoryMock.Verify(x => x.SaveAsync(photoGalleryDto), Times.Once);
        }

    }

}
