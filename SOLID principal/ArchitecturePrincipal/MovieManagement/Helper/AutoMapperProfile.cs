using AutoMapper;
using MovieManagementBusiness.DTO;
using MovieManagementDomain.Entities;

namespace MovieManagement.Helper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<MovieDTO, Movie>().ReverseMap();
            CreateMap<ActorDTO, Actor>().ReverseMap();
        }
    }
}
