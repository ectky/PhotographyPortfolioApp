using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.ViewModels
{
    public class GalleryDetailsVM : BaseVM
    {
        public GalleryDetailsVM()
        {
            this.PhotoGalleries = new List<PhotoGalleryDetailsVM>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public UserDetailsVM User { get; set; }
        public virtual List <PhotoGalleryDetailsVM> PhotoGalleries { get; set; }

    }
}
