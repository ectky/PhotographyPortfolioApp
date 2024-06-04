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
    public class UserEditVM :BaseVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required] public int Age { get; set; }

        [Required]
        [DisplayName("Role")]
        public int? RoleId { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
