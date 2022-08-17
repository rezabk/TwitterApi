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
    public class UserRepository : IUserRepository
    {
        private readonly TwitterDbContext _context;

        public UserRepository(TwitterDbContext context)
        {
            _context = context;
        }
        public UserModel GetProfile(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public UserModel GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<bool> CheckPhoneNumber(string phoneNumber, int userId)
        {
            return await _context.Users.AnyAsync(x => x.PhoneNumber == phoneNumber && x.Id != userId);
        }

        public async Task<bool> CheckUserName(string userName, int userId)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userName && x.Id != userId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
