﻿using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using PhotographyPortfolioApp.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Services
{
    public class RoleService : BaseCrudService<RoleDto, IRoleRepository>, IRoleService
    {
        public RoleService(IRoleRepository repository) : base(repository)
        {

        }
    }
}

