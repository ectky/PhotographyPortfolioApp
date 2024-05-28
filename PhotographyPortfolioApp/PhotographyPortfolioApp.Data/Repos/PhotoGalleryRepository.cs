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
    public class PhotoGalleryRepository : BaseRepository<PhotoGallery, PhotoGalleryDto>, IPhotoGalleryRepository
    {
        public PhotoGalleryRepository(PhotographyPortfolioAppDbContext context, IMapper mapper) : base(context, mapper)
        {

        }


    }
}
