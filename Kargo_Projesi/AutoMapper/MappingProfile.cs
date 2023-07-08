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
            CreateMap<UpdateUserDto, User>().ReverseMap();

            CreateMap<CreateRoleDto, Role>().ReverseMap();
            CreateMap<UserLoginDto, Role>().ReverseMap();
            CreateMap<UpdateRoleDto, Role>().ReverseMap();

            CreateMap<LineDto, Line>().ReverseMap();
            CreateMap<StationDto, Station>().ReverseMap();
        }
    }
}
