using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Infrastructure
{
    public class CustomMapperBLL
    {
        private static MapperConfiguration _fromClientProfileToUserDTO;

        static CustomMapperBLL()
        {
            _fromClientProfileToUserDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserProfile, UserDTO>();
                //.ForMember(d => d.Publications, a => a.Ignore())
                //.ForMember(d => d.LikedPublications, a => a.Ignore())
                //.ForMember(d => d.Followers, a => a.Ignore())
                //.ForMember(d => d.Following, a => a.Ignore())
                //.ForMember(d => d.MessageHeaders, a => a.Ignore());

               //g.CreateMap<ApplicationUser, UserDTO>();

            }); 
        }
    }
}
