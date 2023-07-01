using AutoMapper;
using Entity.Concrete;
using Entity.Dto;

namespace WebApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLineDto, Line>().ReverseMap();
            CreateMap<CreateCenterDto, TransferCenter>().ReverseMap();
            CreateMap<CreateAgentaDto, Agenta>().ReverseMap();
            CreateMap<CreateStationDto, Station>().ReverseMap();
            CreateMap<UpdateAgentaDto, Agenta>().ReverseMap();
            CreateMap<UpdateLineDto, Line>().ReverseMap();
            CreateMap<UpdateStationDto, Station>().ReverseMap();
            CreateMap<UpdateCenterDto, TransferCenter>().ReverseMap();

            CreateMap<UserRegisterDto, User>().ReverseMap();
        }
    }
}
