using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data.Entities
{
    internal class Role : BaseEntity
    {
        public Role()
        {
            this.Users = new List<User>();
        }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
