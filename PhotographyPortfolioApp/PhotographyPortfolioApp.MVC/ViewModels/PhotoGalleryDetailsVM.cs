using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.ViewModels
{
    public class PhotoGalleryDetailsVM : BaseVM
    {
        public int PhotoId { get; set; }
        public PhotoDetailsVM Photo { get; set; }
        public int GalleryId { get; set; }
        public GalleryDetailsVM Gallery { get; set; }


	}
}
