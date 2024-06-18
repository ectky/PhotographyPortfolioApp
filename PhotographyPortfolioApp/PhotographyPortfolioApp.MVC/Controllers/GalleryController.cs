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
	public class GalleryController : BaseCrudController<GalleryDto, IGalleryRepository, IGalleryService, GalleryEditVM, GalleryDetailsVM>
	{
		private readonly IUserService _userService;

		public GalleryController(IGalleryService service, IMapper mapper, IUserService userService) : base(service, mapper)
		{
			_userService = userService;

        }
		protected override async Task<GalleryEditVM> PrePopulateVMAsync(GalleryEditVM editVM)
		{

			editVM.UserList = (await _userService.GetAllAsync())
			.Select(x => new SelectListItem(x.Username, x.Id.ToString()));

			return editVM;
		}
	}
}
	