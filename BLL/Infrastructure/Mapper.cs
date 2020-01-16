using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;


namespace BLL.Infrastructure
{

    public static class MappingConfiguration
    {
        public static MapperConfiguration ConfigureMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserProfile, UserDTO>()
                     .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                     .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id))
                     .ForMember(dest => dest.Roles, opt => opt.Ignore())
                     .ReverseMap();

                cfg.CreateMap<CommentToCreate, Comment>().ReverseMap();
                cfg.CreateMap<Country, CountryDTO>().ReverseMap();

                cfg.CreateMap<ApplicationRole, RoleDTO>().ReverseMap();

                cfg.CreateMap<UserProfile, UserDTO>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                    .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id))
                    .ReverseMap();

                cfg.CreateMap<ApplicationUser, UserDTO>()
                .ReverseMap();

                cfg.CreateMap<Category, CategoryDTO>()
                        .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Questions.Count()))
                        .ReverseMap();


                cfg.CreateMap<Comment, CommentDTO>().ReverseMap();


                cfg.CreateMap<Question, QuestionDTO>()
                .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count()))
                .ReverseMap();

                cfg.CreateMap<QuestionToCreate, Question>()
                .ReverseMap();

                cfg.CreateMap<UserRegisterDTO, ApplicationUser>().ReverseMap();
            });

            return config;
        }
    }
   
}
