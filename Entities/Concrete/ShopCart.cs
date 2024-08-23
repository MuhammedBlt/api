using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Abstract;
using api.Entities.Concrete;

namespace api.Entities.Concrete
{
    public class ShopCart : IEntity
    {
        public int ShopCartId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int ShopCartQuantity { get; set; }
        public int ShopCartTotal { get; set; }
        public List<CartItem> CartItems { get; set; }= new List<CartItem>();
    }
}