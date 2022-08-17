using BusinessLogic.BusinessLogics.TweetBl;
using DAL.DTO.Tweet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetBl _bl;

        public TweetController(ITweetBl bl)
        {
            _bl = bl;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTweets()
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var res = await _bl.GetAllTweets(userId);
            return StatusCode(res.StatusCode, res);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> NewTweet(NewTweetDto dto)
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var res = await _bl.NewTweet(userId,dto);
            return StatusCode(res.StatusCode, res);
        }

    }
}
