using AutoMapper;
using MultiTenant.Catalog.Core.Callers.Business.Commands;
using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Core.Callers.Business;

public class BusinessMap : Profile
{
    public BusinessMap()
    {
        CreateMap<CreateBusinessCommand, BusinessContract>()
            .ForMember(c => c.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(c => c.Description, opt => opt.MapFrom(x => x.Description))
            .ReverseMap();

        CreateMap<UpdateBusinessCommand, BusinessContract>()
            .ForMember(c => c.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(c => c.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(c => c.Description, opt => opt.MapFrom(x => x.Description))
            .ReverseMap();

        CreateMap<Domain.Entities.Business, BusinessContract>()
            .ForMember(c => c.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(c => c.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(c => c.Description, opt => opt.MapFrom(x => x.Description))
            .ReverseMap();
    }
}