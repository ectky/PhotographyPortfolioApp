using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Service
{
    public interface IBaseCrudService<TModel, TRepository>
        where TModel : BaseModel
        where TRepository : IBaseRepository<TModel>
    {
        Task<TModel> GetByIdIfExistsAsync(int id);
        Task SaveAsync(TModel model);
        Task DeleteAsync(int id);
        Task<IEnumerable<TModel>> GetWithPaginationAsync(int pageSize, int pageNumber);
        Task<bool> ExistsByIdAsync(int id);

    }
}

