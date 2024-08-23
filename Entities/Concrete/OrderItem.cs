using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Abstract;
using api.Entities.Concrete;

namespace api.Entities.Concrete
{
    public class OrderItem:IEntity
    {
         public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    

    }
}