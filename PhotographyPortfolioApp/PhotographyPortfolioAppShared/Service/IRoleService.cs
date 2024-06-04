using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Service
{
    public interface IRoleService : IBaseCrudService<RoleDto, IRoleRepository>
    {

    }
}

