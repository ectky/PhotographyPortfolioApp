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
	public class PhotoController : BaseCrudController<PhotoDto, IPhotoRepository, IPhotoService, PhotoEditVM, PhotoDetailsVM>
	{
        private readonly IUserService _userService;
        public PhotoController(IPhotoService service, IMapper mapper, IUserService userService) : base(service, mapper)
		{
            _userService = userService;
        }
        protected override async Task<PhotoEditVM> PrePopulateVMAsync(PhotoEditVM editVM)
        {

            editVM.UserList = (await _userService.GetAllAsync())
            .Select(x => new SelectListItem(x.Username, x.Id.ToString()));

            return editVM;
        }
    }
}
