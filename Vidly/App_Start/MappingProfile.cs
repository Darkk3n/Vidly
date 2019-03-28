using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         //Domain to Dto
         Mapper.CreateMap<Customer, CustomerDto>();
         Mapper.CreateMap<Movie, MovieDto>();
         Mapper.CreateMap<MembershipType, MembershipTypeDto>();
         Mapper.CreateMap<Genre, GenreDto>();

         // Dto to Domain
         //To ignore key members from mapping to avoid exception
         Mapper.CreateMap<CustomerDto, Customer>()
             .ForMember(c => c.Id, opt => opt.Ignore());

         Mapper.CreateMap<MovieDto, Movie>()
             .ForMember(c => c.Id, opt => opt.Ignore());

         Mapper.CreateMap<MembershipType, MembershipTypeDto>()
            .ForMember(c => c.Id, opt => opt.Ignore());

         Mapper.CreateMap<Genre, GenreDto>()
            .ForMember(c => c.Id, opt => opt.Ignore());
      }
   }
}