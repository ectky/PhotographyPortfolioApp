using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.ViewModels
{
    public class TagDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public int PhotoId { get; set; }
        public PhotoDetailsVM Photo {get;set;}

    }
}
