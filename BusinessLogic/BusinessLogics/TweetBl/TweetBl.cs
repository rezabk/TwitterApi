using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Contracts;
using DAL.DTO.Tweet;
using DAL.Model;
using Data;
using Serilog;

namespace BusinessLogic.BusinessLogics.TweetBl
{
    public class TweetBl : ITweetBl
    {
        private readonly ITweetRepository _tweet;
        private readonly IUserRepository _user;
        private readonly ITweetUserRepository _tweetUser;
        private readonly Serilog.ILogger _logger = Log.Logger;

        public TweetBl(ITweetRepository tweet, IUserRepository user, ITweetUserRepository tweetUser)
        {
            _tweet = tweet;
            _user = user;
            _tweetUser = tweetUser;
        }

        public async Task<StandardResult> NewTweet(int userid, NewTweetDto dto)
        {
            var user = _user.GetUserById(userid);
            if (user is null)
            {
                var err = new StandardResult
                {
                    Messages = new List<string> { "کاربری با آیدی وارد شده پیدا نشد" },
                    StatusCode = 404,
                    Success = false,
                };
                _logger.Error("FinalProject : /GetProfile success:false");
                return err;
            }

            if (string.IsNullOrEmpty(dto.Tweet))
            {
                var err = new StandardResult
                {
                    Messages = new List<string> { "لطفا متن توییت خود را وارد کنید" },
                    StatusCode = 404,
                    Success = false,
                };
                _logger.Error("FinalProject : /NewTweet success:false");
                return err;
            }

            var newTweet = new TweetModel
            {
                Tweet = dto.Tweet,
                UserId = user.Id,
            };
            await _tweet.Add(newTweet);

            var newTweetUser = new TweetUserModel
            {
                Tweet = newTweet,
                TweetId = newTweet.Id,
                User = user,
                UserId = user.Id
            };
            await _tweetUser.Add(newTweetUser);

            var sr = new StandardResult
            {
                Messages = new List<string> { "Tweet Added" },
                StatusCode = 201,
                Success = true
            };
            _logger.Error("TwitterApi : /NewTweet success:true");
            return sr;









        }
    }
}
