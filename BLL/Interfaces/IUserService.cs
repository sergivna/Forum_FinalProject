using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        //Task<IdentityResult> CreateAsync(UserDTO user);
        //Task<ClaimsIdentity> AuthenticateAsync(UserLoginDTO user);
        //void BlockUser(string id);
        //UserDTO GetUserByEmail(string email);
        //UserDTO GetUserById(string id);
        //void Subscribe(string email, string id);
        //void UnSubscribe(string email, string id);
        //ICollection<UserDTO> GetFollowersById(string id);
        //ICollection<UserDTO> GetFollowingById(string id);
        //ICollection<UserDTO> GetAll();
        //ICollection<UserDTO> GetUsersByCity(string city);
        //IdentityResult Delete(string id);
        //void Dispose();

         int Test();
        Task<UserDTO> GetUser(int id);
        Task SavePhoto(string photoPath, int userId);
        Task UpdateUser(UserDTO user);
    }
}
