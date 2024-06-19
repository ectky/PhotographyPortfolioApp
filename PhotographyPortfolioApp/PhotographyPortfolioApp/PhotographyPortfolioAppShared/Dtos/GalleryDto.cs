using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class GalleryDto
    {
        public GalleryDto()
        {
            this.PhotoGalleries = new List<PhotoGalleryDto>();
        }

        public string Name { get; set; }

        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual UserDto User { get; set; }
        public GalleryType GalleryType { get; set; }
        public virtual List<PhotoGalleryDto> PhotoGalleries { get; set; }
    }
}
