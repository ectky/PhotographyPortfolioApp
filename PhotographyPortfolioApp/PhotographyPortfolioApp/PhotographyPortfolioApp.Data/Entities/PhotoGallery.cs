using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data.Entities
{
    public class PhotoGallery : BaseEntity
    {
        public int PhotoId { get; set; }
        public int GalleryId { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual Gallery Gallery { get; set; }
    }
}
