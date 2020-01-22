using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = MappingConfiguration.ConfigureMapper().CreateMapper();
        }

        public async Task AddQuestion(QuestionToCreate questionDTO)
        {
            var question = mapper.Map<Question>(questionDTO);

            question.DateOfCreate = DateTime.Now;

            await unitOfWork.Questions.Create(question);
            await unitOfWork.SaveChanges();
        }

        public async Task<bool> DeleteQuestion(int id)
        {   
            unitOfWork.Questions.Delete(id);
            return await unitOfWork.SaveChanges();
        }

        public async Task<QuestionDTO> GetQuestion(int id)
        {
            var question = await unitOfWork.Questions.GetById(id);
            return mapper.Map<QuestionDTO>(question);
        }

        public async Task<IEnumerable<QuestionDTO>> GetQuestionsByCategoryId(int id)
        {
            var questions = await unitOfWork.Questions.GetAll();
            var result = questions.Where(cat => cat.CategoryId == id).ToList();
            var res = mapper.Map<IEnumerable<QuestionDTO>>(result);
            return res;
        }

    }
}
