using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.ViewModels
{
    public class RoleDetailsVM : BaseVM
    {
        public RoleDetailsVM()
        {
            this.Users = new List<UserDetailsVM>();
        }
        public string Name { get; set; }
        public  List<UserDetailsVM> Users { get; set; }
        
    }
}
