using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using PhotographyPortfolioApp.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Services
{
    public abstract class BaseCrudService<TModel, TRepository> : IBaseCrudService<TModel, TRepository>
        where TModel : BaseModel
        where TRepository : IBaseRepository<TModel>
    {
        protected readonly TRepository _repository;
        protected BaseCrudService(TRepository repository)
        {
            this._repository = repository;
        }
        public virtual async Task SaveAsync(TModel model)
        {
            if (Equals(model, null))
            {
                throw new ArgumentNullException(nameof(model));
            }

            await this._repository.SaveAsync(model);
        }
        public virtual Task DeleteAsync(int id)
            => this._repository.DeleteAsync(id);
        public virtual Task<TModel> GetByIdIfExistsAsync(int id)
            => this._repository.GetByIdAsync(id);
        public virtual Task<IEnumerable<TModel>> GetWithPaginationAsync(int pageSize, int pageNumber)
            => this._repository.GetWithPaginationAsync(pageSize, pageNumber);
        public Task<bool> ExistsByIdAsync(int id)
            => this._repository.ExistsByIdAsync(id);
    }
}
