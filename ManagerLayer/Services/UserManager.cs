using CommonLayer.Request_Model;
using ManagerLayer.Interfaces;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Services
{
    public class UserManager : IUserManager
    {
        public readonly IUserRepo UserManagerObj;
        public UserManager(IUserRepo userManagerObj)
        {
            this.UserManagerObj = userManagerObj;
        }

        public UserEntity registration(RegisterReqModel model)
        {
            return UserManagerObj.registration(model);
        }

        public string UserLogin(LoginReqModel model)
        {
            return UserManagerObj.UserLogin(model);
        }
    }
}
