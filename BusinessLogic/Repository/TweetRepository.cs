using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Contracts;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repository
{
    public class TweetRepository : ITweetRepository
    {
        private readonly TwitterDbContext _context;

        public TweetRepository(TwitterDbContext context)
        {
            _context = context;
        }
        public async Task<List<TweetModel>> GetAllTweets()
        {
            return await _context.Tweets.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<bool> Add(TweetModel tweet)
        {
            await _context.Tweets.AddAsync(tweet);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
