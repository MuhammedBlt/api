using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class ProductRequest
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }
        
    }
    }
