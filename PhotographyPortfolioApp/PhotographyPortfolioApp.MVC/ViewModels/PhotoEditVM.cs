﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PhotographyPortfolioApp.ViewModels
{
    public class PhotoEditVM : BaseVM
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int Pixels { get; set; }
        [Required]
        public byte[] PhotoArray { get; set; }
        public IFormFile PhotoFile { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }
        public IEnumerable <SelectListItem> UserList { get; set; }



	}
}
