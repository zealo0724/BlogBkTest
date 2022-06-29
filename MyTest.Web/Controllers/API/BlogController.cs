using Microsoft.AspNetCore.Mvc;
using MyTest.Data;
using MyTest.Model;

namespace MyTest.Web.Controllers.API
{
    public class BlogController : Controller
    {
        private IAdminRepository _adminRepository;

        public BlogController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            //for better performance, can create an REST api to make every features to micro ones
            var blogs = await _adminRepository.GetBlogs();

            return Ok(blogs);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog)
        {
            var blogs = await _adminRepository.AddBlog(blog);

            return Ok(blogs);
        }

        [HttpDelete]
        public IActionResult DeleteBlog(Blog blog)
        {
            _adminRepository.DeleteBlog(blog);

            return Ok();
        }
    }
}
