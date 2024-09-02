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
        public int? ProductId { get; set; }
        public int ProductName { get; set; }
        public Product? Product { get; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int Quantity { get; set; }

        public int? OrderId { get; set; }

        public Order? Order { get; set; }
        public int Total { get; set; }

        
    }
}