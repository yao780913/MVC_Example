using AutoMapper;
using MoshMVC.Dtos;
using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoshMVC
{
    public class MappingProfile: Profile
    {
        public static void Configuration()
        {
            Mapper.Initialize(cfg =>
           {
               cfg.CreateMap<Movie, MovieDto>();
               cfg.CreateMap<MovieDto, Movie>();
               cfg.CreateMap<GenreDto, Genre>();
               cfg.CreateMap<Genre, GenreDto>();
           });
        }
    }
}