using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class PhotoGalleryDto
    {
        public int PhotoId { get; set; }
        public int GalleryId { get; set; }
        public virtual PhotoDto Photo { get; set; }
        public virtual GalleryDto Gallery { get; set; }
    }
}
