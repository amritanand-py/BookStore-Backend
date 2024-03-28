using CommonLayer.Request_Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface IUserManager
    {
        public UserEntity registration(RegisterReqModel model);
        public string UserLogin(LoginReqModel model);
        public ForgetPassModel ForgetPassword(string Email);
        /*public bool checker(string Email);*/
    }
}
