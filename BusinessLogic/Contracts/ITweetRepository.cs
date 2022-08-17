﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace BusinessLogic.Contracts
{
    public interface ITweetRepository
    {
        Task<bool> Add(TweetModel tweet);

    }
}
