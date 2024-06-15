using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
