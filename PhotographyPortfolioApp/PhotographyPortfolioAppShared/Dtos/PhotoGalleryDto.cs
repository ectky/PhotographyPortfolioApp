using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class PhotoGalleryDto : BaseModel
    {
        public int PhotoId { get; set; }
        public int GalleryId { get; set; }
        public PhotoDto Photo { get; set; }
        public GalleryDto Gallery { get; set; }
    }
}
