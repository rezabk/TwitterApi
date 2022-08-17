using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class TweetModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Tweet { get; set; }

        public bool IsDeleted { get; set; }

        public List<TweetUserModel> TweetUser { get; set; }


        public TweetModel()
        {
            IsDeleted = false;
        }
    }
}
