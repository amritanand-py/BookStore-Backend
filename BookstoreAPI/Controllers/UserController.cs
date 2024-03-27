using CommonLayer.Request_Model;
using CommonLayer.Response_model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;
using RepoLayer.Interfaces;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase    
    {
        public readonly IUserRepo usermanager;
        //public readonly IBus bus;


        public UserController(IUserRepo usermanager)
        {
            this.usermanager = usermanager;
            /*this.bus = bus;*/
        }

        [HttpPost]
        [Route("Registration")]
        public ActionResult UserRegistration(RegisterReqModel model)
        {
            var tempVar = usermanager.registration(model);

            if (tempVar != null)
            {
                return Ok(new BookstoreResponse<UserEntity> { Success = true, Message = "Regestration Successful", Data = tempVar });
            }
            return BadRequest(new BookstoreResponse<UserEntity> { Success = true, Message = "Regestration Unsuccessful", Data = null });
        }


        [HttpPost]
        [Route("Login")]
        public ActionResult UserLogin(LoginReqModel model)
        {
            var Response = usermanager.UserLogin(model);
            if (Response != null)
            {
                return Ok(new BookstoreResponse<string> { Success = true, Message = "login Successful", Data = Response });
            }
            return BadRequest(new BookstoreResponse<bool> { Success = true, Message = "Login Unsuccessful", Data = false });
        }







    }
}   
