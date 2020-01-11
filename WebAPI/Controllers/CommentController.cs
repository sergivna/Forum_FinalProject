using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet()]
        [Route("{id}")]
        public async Task<IActionResult> GetCommentsByQuestion(int questionId)
        {
            var comments = await commentService.GetCommentsByQuestion(questionId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentToCreate comment)
        {
             var result = await commentService.AddComment(comment);
            return Ok(result);
        }
    }
}