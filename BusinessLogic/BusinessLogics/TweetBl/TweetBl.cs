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
using BusinessLogic.Utils;
namespace BusinessLogic.BusinessLogics.TweetBl
{
    public class TweetBl : ITweetBl
    {
        private readonly ITweetRepository _tweet;
        private readonly IUserRepository _user;
        private readonly ITweetUserRepository _tweetUser;
        private readonly Mapper _mapper;
        private readonly Serilog.ILogger _logger = Log.Logger;

        public TweetBl(ITweetRepository tweet, IUserRepository user, ITweetUserRepository tweetUser, Mapper mapper)
        {
            _tweet = tweet;
            _user = user;
            _tweetUser = tweetUser;
            _mapper = mapper;
        }

        public async Task<StandardResult> GetAllTweets(int userid)
        {
            var tweets = await _tweet.GetAllTweets();
            if (tweets.Count == 0)
            {
                var er = new StandardResult
                {
                    Messages = new List<string> { "No Tweets Found" },
                    StatusCode = 404,
                    Success = false,
                };
                _logger.Error("TwitterApi : /GetAllTweets success:false");
                return er;
            }

            var tweetsList = new List<ShowTweetsDto>();
            foreach (var item in tweets)
            {
                var tempDto = await _mapper.MapAsync(item, new ShowTweetsDto());
                tweetsList.Add(tempDto);
            }
            var sr = new StandardResult<List<ShowTweetsDto>>
            {
                Messages = new List<string> { "Tweets Retrived" },
                Result = tweetsList,
                StatusCode = 200,
                Success = true,
            };
            _logger.Information("TwitterApi : /GetAllTweets success:true");
            return sr;




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
                _logger.Error("TwitterApi : /NewTweet success:false");
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
                _logger.Error("TwitterApi : /NewTweet success:false");
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
