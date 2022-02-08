using AutoMapper;
using SSentryTestBackend.Core.DTOs;
using SSentryTestBackend.Core.Entities;

namespace SSentryTestBackend.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
