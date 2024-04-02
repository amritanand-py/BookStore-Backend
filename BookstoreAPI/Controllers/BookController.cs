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
    public class BookController : ControllerBase
    {
        public readonly IBookRepo bookmanager;

        public BookController(IBookRepo bookmanager)
        {
            this.bookmanager = bookmanager;
        }




        [HttpPost]
        [Route("Create")]
        public ActionResult AddBook(BookCreationReq model)
        {
            var tempVar = bookmanager.BookAddition(model);

            if (tempVar != null)
            {
                return Ok(new BookstoreResponse<BookEntity> { Success = true, Message = "Regestration Successful", Data = tempVar });
            }
            return BadRequest(new BookstoreResponse<BookEntity> { Success = true, Message = "Regestration Unsuccessful", Data = null });
        }



    }
}