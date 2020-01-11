using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;


        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public int Test()
        {
            unitOfWork.Categories.GetById(1);
          
            return 5;
        }

       public async Task<UserDTO> GetUser(int id)
        {
            var user = await unitOfWork.UserProfiles.GetById(id);
            if(user == null)
            {
                throw new Exception("User isn`t exist");
            }
            
            var userReturn = CustomMapperBLL._fromClientProfileToUserDTO.CreateMapper().Map<UserProfile, UserDTO>(user);
            return userReturn;
        }

        public async Task SavePhoto(string photoPath, int userId)
        {
           var user = await unitOfWork.UserProfiles.GetById(userId);
            user.PhotoPath = photoPath;
            await unitOfWork.SaveChanges();

        }

        public  async Task UpdateUser(UserDTO user)
        {
            var userUpdate = await unitOfWork.UserProfiles.GetById(user.Id);
            userUpdate.Name = user.Name;
            userUpdate.Surname = user.Surname;
            //var country = await unitOfWork.Countries.GetById(user.CountryId);
            userUpdate.CountryId = user.CountryId;
            userUpdate.Birthday = user.Birthday;

            unitOfWork.UserProfiles.Update(userUpdate);
            await unitOfWork.SaveChanges();
        }
    }
}
