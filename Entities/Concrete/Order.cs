using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using api.Entities.Abstract;
using api.Entities.Concrete;

namespace api.Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set;}
        public DateTime OrderDate { get; set;}
        public List<OrderItem>OrderItems { get; set;}= new List<OrderItem>();
        public int CustomerId { get; set; }






    }
}