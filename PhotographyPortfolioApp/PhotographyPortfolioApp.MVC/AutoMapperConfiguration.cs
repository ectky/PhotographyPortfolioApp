using AutoMapper;
using PhotographyPortfolioApp.Data.Entities;
using PhotographyPortfolioApp.Shared.Dtos;
using PhotographyPortfolioApp.ViewModels;

namespace PhotographyPortfolioApp.MVC
{
    internal class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Gallery, GalleryDto>().ReverseMap();
            CreateMap<GalleryDto, GalleryEditVM>().ReverseMap();
            CreateMap<GalleryDto, GalleryDetailsVM>().ReverseMap();

            CreateMap<Photo, PhotoDto>().ReverseMap();
            CreateMap<PhotoDto, PhotoEditVM>().ReverseMap();
            CreateMap<PhotoDto, PhotoDetailsVM>().ReverseMap();

            CreateMap<PhotoGallery, PhotoGalleryDto>().ReverseMap();
            CreateMap<PhotoGalleryDto, PhotoGalleryDetailsVM>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleDto, RoleEditVM>().ReverseMap();
            CreateMap<RoleDto, RoleDetailsVM>().ReverseMap();

            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<TagDto, TagEditVM>().ReverseMap();
            CreateMap<TagDto, TagDetailsVM>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserEditVM>().ReverseMap();
            CreateMap<UserDto, UserDetailsVM>().ReverseMap();


        }
    }
}
