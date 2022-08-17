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
    public class AuthRepository : IAuthRepository
    {
        private readonly TwitterDbContext _context;

        public AuthRepository(TwitterDbContext context)
        {
            _context = context;
        }
        public async Task<UserModel> RegisterUser(UserModel userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public UserModel GetUserByUserNameOrEmailAndPassword(string userNameOrEmail, string password)
        {
            return _context.Users.SingleOrDefault(x =>
                (x.Email == userNameOrEmail || x.UserName == userNameOrEmail) && x.Password == password && x.IsActive == true && x.IsDeleted == false);

        }
        public async Task<bool> CheckEmailForRegister(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> CheckPhoneNumberForRegister(string phoneNumber)
        {
            return await _context.Users.AnyAsync(x => x.PhoneNumber == phoneNumber);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
