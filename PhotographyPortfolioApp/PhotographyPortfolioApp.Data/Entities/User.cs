using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data.Entities
{
    internal class User : BaseEntity
    { 
        public User() 
        {
            this.UploadedPhotos = new List<Photo>();
            this.Galleries = new List<Gallery>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Photo> UploadedPhotos { get; set; }
        public virtual List <Gallery> Galleries { get; set; }

       
    }
}
