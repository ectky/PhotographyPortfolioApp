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
	public class UserController : BaseCrudController<UserDto, IUserRepository, IUserService, UserEditVM, UserDetailsVM>
	{
		private readonly IRoleService _roleService;
		private readonly IPhotoService _photoService;

		public UserController(IUserService service, IMapper mapper, IRoleService roleService, IPhotoService photoService) : base(service, mapper)
		{
			_roleService = roleService;
			_photoService = photoService;
		}
		protected override async Task<UserEditVM> PrePopulateVMAsync(UserEditVM editVM)
		{

			editVM.RoleList = (await _roleService.GetAllAsync())
			.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

			return editVM;
		}
	}
}

