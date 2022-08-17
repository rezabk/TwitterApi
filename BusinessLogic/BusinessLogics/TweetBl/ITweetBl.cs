using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Tweet;
using Data;

namespace BusinessLogic.BusinessLogics.TweetBl
{
    public interface ITweetBl
    {
        Task<StandardResult> GetAllTweets(int userid);
        Task<StandardResult> NewTweet(int userid, NewTweetDto dto);

    }
}
