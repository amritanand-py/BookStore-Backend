﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Request_Model
{
    public class AddToCartRequestModel
    {
        
        
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }

}

