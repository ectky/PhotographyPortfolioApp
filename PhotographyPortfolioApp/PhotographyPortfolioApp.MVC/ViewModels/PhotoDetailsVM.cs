using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.ViewModels
{
    public class PhotoDetailsVM:BaseVM
    {
        public PhotoDetailsVM() 
        {
            this.Tags = new List<TagDetailsVM>();
            this.PhotoGalleries = new List<PhotoGalleryDetailsVM>();
        }
        public string Description {  get; set; }
        public int Pixels { get; set; }
        public int UserId { get; set; }
        public byte[] PhotoArray { get; set; }

        public List<TagDetailsVM> Tags { get; set; }
        public List<PhotoGalleryDetailsVM> PhotoGalleries { get; set; }

	}
}
