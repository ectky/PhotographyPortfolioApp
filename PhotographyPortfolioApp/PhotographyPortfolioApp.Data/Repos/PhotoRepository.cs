using AutoMapper;
using PhotographyPortfolioApp.Data.Entities;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data.Repos
{
    public class PhotoRepository : BaseRepository<Photo, PhotoDto>, IPhotoRepository
    {
        public PhotoRepository(PhotographyPortfolioAppDbContext context, IMapper mapper) : base(context, mapper)
        {

        }


    }
}
