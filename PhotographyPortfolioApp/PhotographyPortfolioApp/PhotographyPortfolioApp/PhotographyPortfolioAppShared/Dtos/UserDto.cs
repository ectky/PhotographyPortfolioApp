using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class UserDto
    {
        public User()
        {
            this.UploadedPhotos = new List<PhotoDto>();
            this.Galleries = new List<GalleryDto>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? RoleId { get; set; }
        public virtual RoleDto Role { get; set; }
        public virtual List<PhotoDto> UploadedPhotos { get; set; }
        public virtual List<GalleryDto> Galleries { get; set; }
    }
}
