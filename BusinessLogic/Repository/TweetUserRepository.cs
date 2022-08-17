using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Contracts;
using DAL;
using DAL.Model;

namespace BusinessLogic.Repository
{
    public class TweetUserRepository : ITweetUserRepository
    {
        private readonly TwitterDbContext _context;

        public TweetUserRepository(TwitterDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(TweetUserModel tweetUserModel)
        {
            await _context.TweetUsers.AddAsync(tweetUserModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
