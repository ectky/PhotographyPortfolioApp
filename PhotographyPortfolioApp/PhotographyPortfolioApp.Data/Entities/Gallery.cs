using PhotographyPortfolioApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data.Entities
{
    public class Gallery : BaseEntity
    {
        public Gallery()
        {
            this.PhotoGalleries = new List<PhotoGallery>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public GalleryType GalleryType { get; set; }
        public virtual List<PhotoGallery> PhotoGalleries { get; set; }

    }
}
