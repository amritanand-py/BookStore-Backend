using CommonLayer.Request_Model;
using Microsoft.EntityFrameworkCore;
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
    public class CartServices:ICartRepo
    {
        public readonly BookStoreContext BookStoreContext;
        public CartServices(BookStoreContext BookStoreContext)
        {
            this.BookStoreContext = BookStoreContext;
        }
        /*     --------------------------------------------------------------------------------------*/

        public CartEntity AddToCart(AddToCartRequestModel request)
        {
            // Create a new CartItemEntity object using data from the request
            var cartItem = new CartEntity
            {
                UserId = request.UserId,
                BookId = request.BookId,
                Quantity = request.Quantity
            };

            // Add the cart item to the database
            BookStoreContext.CartItems.Add(cartItem);
            BookStoreContext.SaveChanges();
            return cartItem;
        }
        /*     --------------------------------------------------------------------------------------*/


    }
}
