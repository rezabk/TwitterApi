using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Auth
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }



    }
}
