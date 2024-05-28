using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Dtos
{
    public class TagDto : BaseModel
    {
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public PhotoDto Photo { get; set; }
    }
}
