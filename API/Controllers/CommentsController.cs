using Application;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseApiController
    {

        private ICommentService _svc;

        public CommentsController(ICommentService svc)
        {
            _svc = svc;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ReadCommentDto>>> GetComments(Guid activityId)
        {
            var comments = await _svc.GetComments(activityId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<ActionResult<ReadCommentDto>> CreateComment(CreateCommentDto c)
        {
            var comment = await _svc.CreateComment(c);
            return Created("Comment created", comment);
        }
    }
}
