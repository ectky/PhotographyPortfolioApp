using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class PhotoDto
    {
        public PhotoDto()
        {
            this.Tags = new List<TagDto>();
            this.PhotoGalleries = new List<PhotoGalleryDto>();
        }
        public string Description { get; set; }
        public int Pixels { get; set; }
        public int UserId { get; set; }
        public virtual UserDto User { get; set; }
        public byte[] PhotoArray { get; set; }
        public virtual List<TagDto> Tags { get; set; }
        public virtual List<PhotoGalleryDto> PhotoGalleries { get; set; }
    }
}
