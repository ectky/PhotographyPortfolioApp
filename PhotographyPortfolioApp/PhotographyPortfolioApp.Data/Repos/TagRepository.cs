﻿using AutoMapper;
using PhotographyPortfolioApp.Data.Entities;
using PhotographyPortfolioApp.Shared.Attributes;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data.Repos
{
    [AutoBind]
    public class TagRepository : BaseRepository<Tag, TagDto>, ITagRepository
    {
        public TagRepository(PhotographyPortfolioAppDbContext context, IMapper mapper) : base(context, mapper)
        {

        }


    }
}
