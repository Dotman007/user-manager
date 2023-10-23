using AutoMapper;
using UserManager.Domain.Dto;
using UserManager.Domain.Entities;

namespace UserManager.Application.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, ApplicationUser>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
           .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
           .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
           .ForMember(dest => dest.NationalityId, opt => opt.MapFrom(src => src.NationalityId));


            CreateMap<ApplicationUser, UserList>()
          .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
          .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
          .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
          .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
          .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
          .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality.Name));


            CreateMap<EditUserDto, ApplicationUser>()
          .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
          .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
          .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
          .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
          .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
          .ForMember(dest => dest.NationalityId, opt => opt.MapFrom(src => src.NationalityId));


            //EditUserDto
            // Add more mappings as needed
        }
    }
}
