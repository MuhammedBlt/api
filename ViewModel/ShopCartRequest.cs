using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Concrete;

namespace api.ViewModel
{
    public class ShopCartRequest
    {
        public int Total { get; set; }
        public Product? Product { get; set; }

        public int OrderQuantity { get; set; }
    }
}