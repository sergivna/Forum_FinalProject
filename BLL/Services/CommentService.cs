﻿using AutoMapper;
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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = MappingConfiguration.ConfigureMapper().CreateMapper();
        }

        public async Task<CommentDTO> AddComment(CommentToCreate comment)
        {

            //var commentToCreate = new Comment
            //{
            //    Message = comment.Message,
            //    QuestionId = comment.QuestionId,
            //    DateOfCreate = DateTime.Now,
            //    UserId = comment.UserId,
            //};

            var commentToCreate = mapper.Map<Comment>(comment);

            await unitOfWork.Comments.Create(commentToCreate);
            await unitOfWork.SaveChanges();

            
            var commentToReturn = mapper.Map<CommentDTO>(commentToCreate);
            commentToReturn.Question = mapper.Map<QuestionDTO>(await unitOfWork.Questions.GetById(comment.QuestionId));
            commentToReturn.User = mapper.Map<UserDTO>(await unitOfWork.UserProfiles.GetById(comment.UserId));
            return commentToReturn;
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsByQuestion(int questionId)
        {
            var comments = await unitOfWork.Comments.GetAll();
            var result = comments.Where(q => q.Question.Id == questionId).ToList();
            return mapper.Map<IEnumerable<CommentDTO>>(result);
        }
    }
}
