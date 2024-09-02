using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Concrete;

namespace api.ViewModel
{
    public class CartRequest
    {
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    }
}