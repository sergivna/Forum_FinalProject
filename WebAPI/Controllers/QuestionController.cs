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
    [ApiController]
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


        [HttpPost]
        public async Task<IActionResult> AddQuestion(QuestionToCreate question)
        {
                if(question.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            await questionService.AddQuestion(question);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(int id, int userId)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))          
            //    return Unauthorized();

            if (await questionService.DeleteQuestion(id))
                return NoContent();

            return BadRequest("Eror in deleting topic");
        }

    }
}