using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace BusinessLogic.Contracts
{
    public interface IAuthRepository
    {
        Task<UserModel> RegisterUser(UserModel userModel);

        UserModel GetUserByUserNameOrEmailAndPassword(string userNameOrEmail, string password);

        Task<bool> CheckEmailForRegister(string email);

        Task<bool> CheckPhoneNumberForRegister(string phoneNumber);

        void Save();
    }
}
