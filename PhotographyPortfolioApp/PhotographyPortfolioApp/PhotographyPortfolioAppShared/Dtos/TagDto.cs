using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class TagDto
    {
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public virtual PhotoDto Photo { get; set; }
    }
}
