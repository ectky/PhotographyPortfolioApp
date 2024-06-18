using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data.Entities
{
    public class Photo : BaseEntity
    {
        public Photo()
        {
            this.Tags = new List<Tag>();
            this.PhotoGalleries = new List<PhotoGallery>();
        }
        public string Description { get; set; }
        public int Pixels { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public byte[] PhotoArray { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<PhotoGallery> PhotoGalleries { get; set; }

    }
}
