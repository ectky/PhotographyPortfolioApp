using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.ViewModels
{
    public class RoleEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
    }
}
