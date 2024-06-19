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
        private readonly IUserService _userService;
        public TagController(ITagService service, IMapper mapper, IUserService userService) : base(service, mapper)
		{
            _userService = userService;
        }
        protected override async Task<TagEditVM> PrePopulateVMAsync(TagEditVM editVM)
        {

            editVM.PhotoList = (await _userService.GetAllAsync())
            .Select(x => new SelectListItem(x.Username, x.Id.ToString()));

            return editVM;
        }
    }
}
