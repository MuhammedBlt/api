using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Concrete;

namespace api.ViewModel
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
    }
}