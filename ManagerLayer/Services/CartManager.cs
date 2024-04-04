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
    public class CartManager:ICartManager
    {
        public readonly ICartRepo CartManagerObj;

        public CartEntity AddToCart(AddToCartRequestModel request)
        {
            return CartManagerObj.AddToCart(request);
        }
        public List<CartEntity> GetCartItems(int userId)
        {
            return CartManagerObj.GetCartItems(userId);
        }
    }
}
