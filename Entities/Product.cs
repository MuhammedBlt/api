using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public decimal Price { get; set; }
        public List<Order> Orders { get; set; }


    }
    
}