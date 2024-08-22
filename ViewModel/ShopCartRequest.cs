using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Concrete;

namespace api.ViewModel
{
    public class ShopCartRequest
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int ShopCartQuantity { get; set; }
        public int ShopCartTotal { get; set; }
    }
}