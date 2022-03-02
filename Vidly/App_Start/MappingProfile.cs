using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomerDto>();
                
            Mapper.CreateMap<CustomerDto, Customers>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            // Mapper Configuration For Movies
            Mapper.CreateMap<Movie, MovieDto>();
                
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, membershipTypeDto>();

            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}