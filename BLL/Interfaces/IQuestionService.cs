using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDTO>> GetQuestionsByCategoryId(int id);
        Task<QuestionDTO> GetQuestion(int id);
        Task AddQuestion(QuestionToCreate questionDTO);
        Task<bool> DeleteQuestion(int id);
    }
}
