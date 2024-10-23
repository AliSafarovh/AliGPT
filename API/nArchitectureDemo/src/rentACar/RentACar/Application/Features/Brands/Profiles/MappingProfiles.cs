using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entites;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles:Profile
    { 
        public MappingProfiles()
        {
            CreateMap<Brand,CreateBrandCommand>().ReverseMap();
            CreateMap<Brand,CreatedBrandResponse>().ReverseMap();
            CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
            CreateMap<Paginate<Brand>,GetListResponse<GetListBrandListItemDto>>().ReverseMap();
        }
    }
}
