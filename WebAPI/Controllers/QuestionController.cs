using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]

    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestions(int categoryId)
        {
            var result = await questionService.GetQuestionsByCategoryId(categoryId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet] 
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            var result = await questionService.GetQuestion(questionId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AddQuestion(QuestionToCreateDTO questionDTO)
        {
            if(questionDTO.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            await questionService.AddQuestion(questionDTO);
            return Ok();
        }

    }
}