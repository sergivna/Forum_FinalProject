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


        public UserService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = MappingConfiguration.ConfigureMapper().CreateMapper();
            this.userManager = userManager;
        }

       public async Task<UserDTO> GetUser(int id)
        {
            var user = await unitOfWork.UserProfiles.GetById(id);
         
            var userReturn = mapper.Map<UserDTO>(user);
            return userReturn;
        }

        public async Task SavePhoto(string photoPath, int userId)
        {
           var user = await unitOfWork.UserProfiles.GetById(userId);

            user.PhotoPath = photoPath;
            await unitOfWork.SaveChanges();
        }

        public  async Task<bool> UpdateUser(UserDTO user)
        {
            var userUpdate = await unitOfWork.UserProfiles.GetById(user.Id);

            userUpdate.Name = user.Name;
            userUpdate.Surname = user.Surname;
            userUpdate.CountryId = user.CountryId;
            userUpdate.Birthday = user.Birthday;
            userUpdate.Status = user.Status;


            if (!unitOfWork.UserProfiles.Update(userUpdate))
                return false;


            if (!await unitOfWork.SaveChanges())
                return false;

            return true;
        }
    }
}
