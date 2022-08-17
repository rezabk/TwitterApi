using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
    
        public string LastName { get; set; }
       
        public string UserName { get; set; }
    
        public string Email { get; set; }
    
        public string PhoneNumber { get; set; }
 
        public string Password { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public string? RefreshTokenHash { get; set; }
        [AllowNull]
        public DateTime? RefreshTokenExTime { get; set; }

        public List<TweetUserModel> TweetUser { get; set; }

        public UserModel()
        {
            IsActive = true;
            IsDeleted = false;
        }
        public void Refresh(string refreshTokenHash, DateTime exp)
        {
            RefreshTokenHash = refreshTokenHash;
            RefreshTokenExTime = exp;
        }
        public bool ValidateRefreshToken(string token)
        {
            return RefreshTokenHash.Equals(token);
        }
    }
}
