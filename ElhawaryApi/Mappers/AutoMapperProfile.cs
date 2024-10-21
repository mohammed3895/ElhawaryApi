using AutoMapper;

namespace ElhawaryApi.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TechnicanDTO, Technicans>().ReverseMap();
            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<MaintenanceDTO, Maintenance>().ReverseMap();
            CreateMap<AccessoryDTO, Accessory>().ReverseMap();
        }
    }
}
