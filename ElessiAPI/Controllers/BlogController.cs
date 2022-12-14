using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("blogList")]
        public IActionResult GetAllBlog()
        {
            var blog = _blogService.GetAllBlog();
            if (blog != null)
                return Ok(new { status = 200, message = blog });
            return BadRequest();

        }

        [HttpPost("addBlog")]
        public IActionResult Add(Blog blog)
        {
            var addBlog = _blogService.AddBlog(blog);
            if (addBlog.Success)
                return Ok(new { status = 200, message = addBlog.Message });
            return BadRequest(new { status = 400, message = addBlog.Message });
        }

        [HttpDelete("deleteBlog")]
        public IActionResult DeleteBlog(int id)
        {
            var deleteBlog = _blogService.DeleteBlog(id);
            if (deleteBlog.Success)
                return Ok(new { status = 200, message = deleteBlog.Message });
            return BadRequest();
        }

        [HttpPost("updateBlog")]
        public IActionResult UpdateBlog(Blog blog)
        {
            var updateBlog = _blogService.UpdateBlog(blog);
            if (updateBlog.Success)
                return Ok(new { status = 200, message = updateBlog });
            return BadRequest(new { Status = 400, message = updateBlog });
        }

        [HttpGet("byIdBlog")]
        public IActionResult GetById(int Id)
        {
            var result = _blogService.GetById(Id);
            if (result.Success)
                return Ok(new { status = 200, message = result });
            return BadRequest(new { Status = 200, message = result });
        }

    }
}
