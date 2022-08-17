using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Auth;
using DAL.DTO.User;
using DAL.Model;
using Data;

namespace BusinessLogic.BusinessLogics.UserBl
{
    public interface IUserBl
    {
        Task<StandardResult> GetProfile(int id);
        Task<StandardResult> UpdateProfile(int userid, UpdateUserDto dto);
    }
}
