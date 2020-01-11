using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategory(int id);
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
    }
}
