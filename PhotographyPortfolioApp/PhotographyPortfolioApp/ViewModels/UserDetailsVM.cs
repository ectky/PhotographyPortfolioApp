using PhotographyPortfolioApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.ViewModels
{
    public class UserDetailsVM:BaseVM
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }
        public int? RoleId { get; set; }

        public RoleDetailsVM Role { get; set; }
        public  List<PhotoDetailsVM> UploadedPhotos { get; set; }
        public  List<GalleryDetailsVM> Galleries { get; set; }

    }
}
