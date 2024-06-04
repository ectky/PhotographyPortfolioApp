using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PhotographyPortfolioApp.ViewModels
{
    public class PhotoEditVM : BaseVM
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int Pixels { get; set; }
        [Required]
        public byte[] PhotoArray { get; set; }
        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }
        public IEnumerable <SelectListItem> UserList { get; set; }  

        
    }
}
