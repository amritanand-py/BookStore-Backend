using CommonLayer.Encryption;
using CommonLayer.Request_Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Services
{
    public class UserServices : IUserRepo
    {
        public readonly BookStoreContext BookStoreContext;
        public readonly IConfiguration config;

        public UserServices(BookStoreContext BookStoreContext, IConfiguration config)
        {
            this.BookStoreContext = BookStoreContext;
            this.config = config;
        }
        /*     --------------------------------------------------------------------------------------*/

        public UserEntity registration(RegisterReqModel model)
        {
            UserEntity newUser = new UserEntity();
            newUser.Email = model.Email;
            newUser.Name = model.Name;
            newUser.Phone = model.Phone;
            newUser.Password = EncryptDecryptClass.EncryptionPass(model.Password);
            newUser.role = "Customer";
            BookStoreContext.UserTable.Add(newUser);
            BookStoreContext.SaveChanges();
            return newUser;
        }

        /*     --------------------------------------------------------------------------------------*/
        private string genrateToken(string email, int userID,string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",email),
                new Claim("UserId", userID.ToString()),
                new Claim("Role", role)
            };
            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;

        }
        /*     --------------------------------------------------------------------------------------*/

        public string UserLogin(LoginReqModel model)
        {
            var tempvar = BookStoreContext.UserTable.FirstOrDefault(x => x.Email == model.Email);
            if (tempvar == null)
            {
                return null;
            }
            else
            {
                // tempvar[0].Password == model.Password
                if (EncryptDecryptClass.MatchPass(tempvar.Password, model.Password))
                {
                    var token = genrateToken(tempvar.Email, tempvar.UserId, tempvar.role);
                    return token;
                }

                return null;
            }
        }
        /*     --------------------------------------------------------------------------------------*/

        public ForgetPassModel ForgetPassword(string Email)
        {
            UserEntity User = BookStoreContext.UserTable.FirstOrDefault(x => x.Email == Email);
            ForgetPassModel forgetPassword = new ForgetPassModel();
            forgetPassword.Email = User.Email;
            forgetPassword.userID = User.UserId;
            forgetPassword.Token = genrateToken(User.Email, User.UserId, User.role);
            return forgetPassword;
        }
        /*     --------------------------------------------------------------------------------------*/
        public bool checker(string Email)
        {
            if (BookStoreContext.UserTable.ToList().Find(x => x.Email == Email) != null)
            {
                return true;
            }
            return false;
        }
        /*     --------------------------------------------------------------------------------------*/
        public bool ResetPassword(string Email, ResetPasswordModel reset)
        {
            UserEntity User = BookStoreContext.UserTable.FirstOrDefault(x => x.Email == Email);

            if (User != null)
            {
                User.Password = EncryptDecryptClass.EncryptionPass(reset.Password);
                BookStoreContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}