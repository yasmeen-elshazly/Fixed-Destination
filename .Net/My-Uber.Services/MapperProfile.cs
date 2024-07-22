using AutoMapper;
using My_Uber.DTOs;
using Models;

namespace My_Uber.Services.MP
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Mapping between BuildingDTO and BuildingModel
            CreateMap<BuildingDTO, BuildingModel>().ReverseMap();
        }
    }
}
