using CommonLayer.Request_Model;
using CommonLayer.Response_model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using RepoLayer.Services;

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
        /*     --------------------------------------------------------------------------------------*/
        [HttpPost]
        [Route("Create")]
        public ActionResult AddBook(BookCreationReq model)
        {
            var tempVar = bookmanager.BookAddition(model);

            if (tempVar != null)
            {
                return Ok(new BookstoreResponse<BookEntity> { Success = true, Message = "Regestration Successful", Data = tempVar });
            }
            return BadRequest(new BookstoreResponse<BookEntity> { Success = false, Message = "Regestration Unsuccessful", Data = null });
        }
        /*     --------------------------------------------------------------------------------------*/

        [HttpPut]
        [Route("getbyID")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var model = new getbyID { BookId = id };
                var book = bookmanager.GetByID(model);
                if (book == null)
                {
                    return NotFound(); // Return 404 if book is not found
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        /*     --------------------------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult GetBooks(int page = 1, int pageSize = 10)
        {
            try
            {
                var paginatedBooks = bookmanager.GetBooks(page, pageSize);
                return Ok(paginatedBooks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /*     --------------------------------------------------------------------------------------*/

    }
}