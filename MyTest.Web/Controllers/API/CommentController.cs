using Microsoft.AspNetCore.Mvc;
using MyTest.Data;
using MyTest.Model;

namespace MyTest.Web.Controllers.API
{
    public class CommentController : Controller
    {
        private IAdminRepository _adminRepository;

        public CommentController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var entities = await _adminRepository.GetComments();

            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var entity = await _adminRepository.AddComment(comment);

            return Ok(entity);
        }

        [HttpDelete]
        public IActionResult DeleteComment(Comment comment)
        {
            _adminRepository.DeleteComment(comment);

            return Ok();
        }
    }
}
