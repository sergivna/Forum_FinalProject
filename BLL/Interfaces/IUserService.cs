using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(int id);
        Task SavePhoto(string photoPath, int userId);
        Task<bool> UpdateUser(UserDTO user);
    }
}
