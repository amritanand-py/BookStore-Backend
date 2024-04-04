using CommonLayer.Request_Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface ICartManager
    {
        public CartEntity AddToCart(AddToCartRequestModel request);
        public List<CartEntity> GetCartItems(int userId);
    }
}
