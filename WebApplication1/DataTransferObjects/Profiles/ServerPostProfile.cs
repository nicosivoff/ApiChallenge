using AutoMapper;
using WebApplication.Domain;

namespace WebApplication.DataTransferObjects.Profiles
{
    public class ServerPostProfile : Profile
    {
        public ServerPostProfile()
        {
            CreateMap<ServerPost, Salida>()
                .ForMember(dest => dest.Titulo,
                           opt => opt.MapFrom(src => src.title));
        }
    }
}
