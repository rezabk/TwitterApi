using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Tweet
{
    public class NewTweetDto
    {
        [Required]
        [MaxLength(500)]
        public string Tweet { get; set; }
    }
}
