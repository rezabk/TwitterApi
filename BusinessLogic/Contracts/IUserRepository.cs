using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace BusinessLogic.Contracts
{
    public interface IUserRepository
    {
        UserModel GetProfile(int id);

        UserModel GetUserById(int id);

        Task<bool> CheckPhoneNumber(string phoneNumber, int userId);
        Task<bool> CheckUserName(string userName, int userId);

        void Save();
    }
}
