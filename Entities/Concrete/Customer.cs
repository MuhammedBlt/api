using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Abstract;
using api.Entities.Concrete;
namespace api.Entities.Concrete
{
    public class Customer : IEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int CustomerId { get; set; }
    }
}