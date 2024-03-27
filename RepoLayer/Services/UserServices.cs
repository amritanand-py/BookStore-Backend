using CommonLayer.Request_Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Services
{
    public class UserServices : IUserRepo
    {
        public readonly BookStoreContext BookStoreContext;

        public UserServices(BookStoreContext BookStoreContext)
        {
            this.BookStoreContext = BookStoreContext;
        }


        public UserEntity registration(RegisterReqModel model)
        {
            UserEntity newUser = new UserEntity();
            newUser.Email = model.Email;
            newUser.Name = model.Name;
            newUser.Phone = model.Phone;
            newUser.Password = model.Password;
            newUser.role = "Customer";
            BookStoreContext.UserTable.Add(newUser);
            BookStoreContext.SaveChanges();

            return newUser;

        }
    }
}
