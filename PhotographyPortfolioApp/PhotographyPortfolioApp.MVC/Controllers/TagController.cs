using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotographyPortfolioApp.Service;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using PhotographyPortfolioApp.Shared.Service.Contracts;
using PhotographyPortfolioApp.ViewModels;

namespace PhotographyPortfolioApp.MVC.Controllers
{
	[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]
	public class TagController : BaseCrudController<TagDto, ITagRepository, ITagService, TagEditVM, TagDetailsVM>
	{
        private readonly IPhotoService _photoService;
        public TagController(ITagService service, IMapper mapper, IPhotoService photoService) : base(service, mapper)
		{
            _photoService = photoService;
        }
        protected override async Task<TagEditVM> PrePopulateVMAsync(TagEditVM editVM)
        {

            editVM.PhotoList = (await _photoService.GetAllAsync())
            .Select(x => new SelectListItem(x.Description, x.Id.ToString()));

            return editVM;
        }
    }
}
