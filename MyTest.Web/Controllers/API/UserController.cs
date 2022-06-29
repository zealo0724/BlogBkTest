using Microsoft.AspNetCore.Mvc;
using MyTest.Data;
using MyTest.Model;

namespace MyTest.Web.Controllers.API
{
    public class UserController : Controller
    {
        private IAdminRepository _adminRepository;

        public UserController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var entity = (await _adminRepository.GetUsers())
                .FirstOrDefault(x =>x.Id == userId);

            return Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var entities = await _adminRepository.GetUsers();

            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var entity = await _adminRepository.AddUser(user);

            return Ok(entity);
        }

        [HttpDelete]
        public IActionResult DeleteUser(User user)
        {
            _adminRepository.DeleteUser(user);

            return Ok();
        }
    }
}
