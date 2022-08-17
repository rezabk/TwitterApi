using BusinessLogic.BusinessLogics.UserBl;
using DAL.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBl _bl;

        public UserController(IUserBl bl)
        {
            _bl = bl;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var res = await _bl.GetProfile(userId);
            return StatusCode(res.StatusCode, res);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditProfile(UpdateUserDto dto)
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var res = await _bl.UpdateProfile(userId,dto);
            return StatusCode(res.StatusCode, res);
        }

    }
}
