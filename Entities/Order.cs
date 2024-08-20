using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Order
    {
        public int OrderId { get; set;}
        public DateTime OrderDate { get; set;}
        public int ProductId { get; set;}  
        public Product Product{ get; set;}


    }
}