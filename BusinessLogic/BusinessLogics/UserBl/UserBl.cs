using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Contracts;
using BusinessLogic.Utils;
using DAL.DTO.Auth;
using DAL.DTO.User;
using Data;
using Serilog;

namespace BusinessLogic.BusinessLogics.UserBl
{
    public class UserBl : IUserBl
    {

        private readonly IUserRepository _user;
        private readonly Mapper _mapper;
        private readonly Serilog.ILogger _logger = Log.Logger;

        public UserBl(IUserRepository user, Mapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }
        public async Task<StandardResult> GetProfile(int id)
        {
            var user = _user.GetUserById(id);
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

            var showUser = await _mapper.MapAsync(user, new ShowUserDto());
            showUser.FullName = user.FirstName + " " + user.LastName;
            var sr = new StandardResult<ShowUserDto>
            {
                Messages = new List<string> { "User Retrived" },
                Result = showUser,
                StatusCode = 200,
                Success = true,
            };
            _logger.Information("FinalProject : /GetProfile success:true");
            return sr;
        }

        public async Task<StandardResult> UpdateProfile(int userid, UpdateUserDto dto)
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
                _logger.Error("FinalProject : /UpdateUser success:false");
                return err;
            }

            var checkPhoneNumber = await _user.CheckPhoneNumber(dto.PhoneNumber, user.Id);
            var checkUserName = await _user.CheckUserName(dto.UserName, user.Id);
            if (checkPhoneNumber)
            {
                var er = new StandardResult
                {
                    Messages = new List<string> { "شماره موبایل در سیستم وجود دارد" },
                    StatusCode = 404,
                    Success = true
                };
                _logger.Information("FinalProject : /UpdateUser success:false");
                return er;
            }
            if (checkUserName)
            {
                var er = new StandardResult
                {
                    Messages = new List<string> { "نام کاربری در سیستم وجود دارد" },
                    StatusCode = 404,
                    Success = true
                };
                _logger.Information("FinalProject : /UpdateUser success:false");
                return er;
            }

            if (checkUserName == false && checkPhoneNumber == false)
            {
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.UserName = dto.UserName;
                user.PhoneNumber = dto.PhoneNumber;

                _user.Save();

                var showUpdatedUser = await _mapper.MapAsync(dto, new ShowUserDto());
                showUpdatedUser.FullName = user.FirstName + " " + user.LastName;
                showUpdatedUser.Email = user.Email;
                var sr = new StandardResult<ShowUserDto>
                {
                    Messages = new List<string> { "User Updated" },
                    Result = showUpdatedUser,
                    StatusCode = 201,
                    Success = true
                };
                _logger.Information("FinalProject : /UpdateUser success:true");
                return sr;
            }

            var errr = new StandardResult
            {
                Messages = new List<string> { "Error Occured" },
                StatusCode = 404,
                Success = true
            };
            _logger.Information("FinalProject : /UpdateUser success:false");
            return errr;

        }
    }
}
