using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class RoleDto
    {
        public RoleDto()
        {
            this.Users = new List<UserDto>();
        }
        public string Name { get; set; }
        public virtual List<UserDto> Users { get; set; }
    }
}
