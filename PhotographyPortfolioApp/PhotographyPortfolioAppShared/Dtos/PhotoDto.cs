using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class PhotoDto : BaseModel
    {
        public PhotoDto()
        {
            this.Tags = new List<TagDto>();
            this.PhotoGalleries = new List<PhotoGalleryDto>();
        }
        public string Description { get; set; }
        public int Pixels { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public byte[] PhotoArray { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<PhotoGalleryDto> PhotoGalleries { get; set; }
    }
}
