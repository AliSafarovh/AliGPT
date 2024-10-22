using Application.Features.Brands.Commands.Create;
using AutoMapper;
using Domain.Entites;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand,CreateBrandCommand>().ReverseMap();
            CreateMap<Brand,CreatedBrandResponse>().ReverseMap();
        }
    }
}
