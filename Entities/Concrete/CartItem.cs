using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities.Concrete
{
    public class CartItem
    {
         public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int ShopCartId { get; set; } // Add this property
        public ShopCart ShopCart { get; set; } // Navigation property
    

    }
}