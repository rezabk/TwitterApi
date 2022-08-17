using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class TweetUserModel
    {
        public int Id { get; set; }

        public int TweetId { get; set; }

        public TweetModel Tweet { get; set; }

        public int UserId { get; set; }

        public UserModel User { get; set; }

        public TweetUserModel()
        {

        }
    }
}
