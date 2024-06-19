using Moq;
using PhotographyPortfolioApp.Data.Entities;
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

namespace PetShelter.Test.Service
{
    public class TagServiceTests
    {
        private readonly Mock<ITagRepository> _tagRepositoryMock = new Mock<ITagRepository>();

        private readonly ITagService _service;

        public TagServiceTests()
        {
            _service = new TagService(_tagRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithVallidData_ThenSaveAsync()
        {
            //Arrange
            var tagDto = new TagDto()
            {
                Id = 0,
                PhotoId = 0,
                Name = "Smtg"
            };

            //Act
            await _service.SaveAsync(tagDto);

            //Assert
            _tagRepositoryMock.Verify(x => x.SaveAsync(tagDto), Times.Once);
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _tagRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _tagRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int tagId)
        {
            //Arrange
            var tagDto = new TagDto()
            {
                Id = 0,
                PhotoId = 0,
                Name = "Smtg"
            };

            _tagRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(tagId))))
                .ReturnsAsync(tagDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(tagId);

            //Assart
            _tagRepositoryMock.Verify(x => x.GetByIdAsync(tagId), Times.Once);
            Assert.That(userResult == tagDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnDefault(int tagId)
        {
            //Arrange
            var tag = (TagDto)default;

            _tagRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(tagId))))
                .ReturnsAsync(tag);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(tagId);

            //Assart
            _tagRepositoryMock.Verify(x => x.GetByIdAsync(tagId), Times.Once);
            Assert.That(userResult == tag);
        }

        [Test]
        public async Task WhenUploadAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var tagDto = new TagDto
            {
                Id = 0,
                PhotoId = 0,
                Name = "Smtg"
            };
            _tagRepositoryMock.Setup(s => s.SaveAsync(It.Is<TagDto>(x => x.Equals(tagDto))))
               .Verifiable();

            //Act
            await _service.SaveAsync(tagDto);

            //Assart
            _tagRepositoryMock.Verify(x => x.SaveAsync(tagDto), Times.Once);
        }
    }
}
