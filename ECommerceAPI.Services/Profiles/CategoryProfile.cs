using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceAPI.Dto.Request;
using ECommerceAPI.Entities;
using ECommercerAPI.Dto.Response;

namespace ECommerceAPI.Services.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(o => o.Id, d => d.MapFrom(x => x.Id))
                .ForMember(o => o.Name, d => d.MapFrom(x => x.Name))
                .ForMember(o => o.Description, d => d.MapFrom(x => x.Description))
                .ReverseMap();

            CreateMap<Category, CategoryRequest>()
                .ForMember(o => o.Name, d => d.MapFrom(x => x.Name))
                .ForMember(o => o.Description, d => d.MapFrom(x => x.Description))
                .ReverseMap();
        }
    }
}
