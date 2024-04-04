using CommonLayer.Request_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Interfaces;
using RepoLayer.Services;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly ICartRepo cartmanager;

        public CartController(ICartRepo cartmanager)
        {
            this.cartmanager = cartmanager;
        }

        /*     --------------------------------------------------------------------------------------*/
        [HttpPost]
        [Route("AddToCart")]
        public IActionResult AddToCart( AddToCartRequestModel request)
        {
            try
            {
                cartmanager.AddToCart(request);
                return Ok(new { Success = true, Message = "Item added to cart successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /*     --------------------------------------------------------------------------------------*/

    }
}
