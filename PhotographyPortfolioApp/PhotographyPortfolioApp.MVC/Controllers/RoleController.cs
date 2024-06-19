using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.Shared.Repos.Contracts;
using PhotographyPortfolioApp.Shared.Service.Contracts;
using PhotographyPortfolioApp.ViewModels;

namespace PhotographyPortfolioApp.MVC.Controllers
{
	[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]
	public class RoleController : BaseCrudController<RoleDto, IRoleRepository, IRoleService, RoleEditVM, RoleDetailsVM>
	{
		public RoleController(IRoleService service, IMapper mapper) : base(service, mapper)
		{

		}
	}
}

