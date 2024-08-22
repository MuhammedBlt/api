using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities.Abstract;
using api.Entities.Concrete;

namespace api.Entities.Concrete
{
    public class Admin:IEntity
    {
        public int AdminId { get; set; }
        public int AdminPassword { get; set; }
        public string AdminName { get; set; }
    }
}