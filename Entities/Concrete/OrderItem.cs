using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Abstract;
using api.Entities.Concrete;

namespace api.Entities.Concrete
{
    public class OrderDetail:IEntity
    {
        public int Quantity { get; set; }
        public int OrderDetailId { get; set;}
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Total { get; set; }

    }
}