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
using System.Linq;
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
            if (user == null)
            {
                throw new Exception("User isn`t exist");
            }          
            var userReturn = Infrastructure.Mapper._fromClientProfileToUserDTO.CreateMapper().Map<UserProfile, UserDTO>(user);
            return userReturn;
        }

        public async Task SavePhoto(string photoPath, int userId)
        {
           var user = await unitOfWork.UserProfiles.GetById(userId);

            if(user == null)
            {
                throw new Exception("User isn`t exsist");
            }

            user.PhotoPath = photoPath;
            await unitOfWork.SaveChanges();
        }

        public  async Task<bool> UpdateUser(UserDTO user)
        {
            var userUpdate = await unitOfWork.UserProfiles.GetById(user.Id);

            if(userUpdate == null)
            {
                throw new Exception("User is not exsist");
            }

            userUpdate.Name = user.Name;
            userUpdate.Surname = user.Surname;
            userUpdate.CountryId = user.CountryId;
            userUpdate.Birthday = user.Birthday;
            userUpdate.Status = user.Status;


            if (!unitOfWork.UserProfiles.Update(userUpdate))
            {
                return false;
            }

            if (!await unitOfWork.SaveChanges())
                return false;

            return true;
        }
    }
}
