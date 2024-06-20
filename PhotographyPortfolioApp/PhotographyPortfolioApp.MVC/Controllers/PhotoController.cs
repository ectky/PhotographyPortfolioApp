using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public override Task<IActionResult> Create([FromForm] PhotoEditVM editVM)
        {
            if (editVM.PhotoFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    editVM.PhotoFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    editVM.PhotoArray = fileBytes;
                }
            }

            return base.Create(editVM);
        }
    }
}
