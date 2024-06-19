using PhotographyPortfolioApp.Shared.Attributes;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using PhotographyPortfolioApp.Shared.Service;
using PhotographyPortfolioApp.Shared.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Service
{
    [AutoBind]
    public class PhotoGalleryService : BaseCrudService<PhotoGalleryDto, IPhotoGalleryRepository>, IPhotoGalleryService
    {
        public PhotoGalleryService(IPhotoGalleryRepository repository) : base(repository)
        {

        }
    }
}

