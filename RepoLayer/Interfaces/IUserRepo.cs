﻿using RepoLayer.Entity;
using CommonLayer.Request_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;

namespace RepoLayer.Interfaces
{
    public interface IUserRepo
    {
        public UserEntity registration(RegisterReqModel model);
    }
}
