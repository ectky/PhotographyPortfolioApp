using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.ViewModels
{
    public class TagEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Photo")]
        public int PhotoId { get; set; }
        public IEnumerable<SelectListItem> PhotoList { get; set; }

    }
}
