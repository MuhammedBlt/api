using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class AdminRequest
    {
        public int AdminId { get; set; }
        public string? AdminPassword { get; set; }

        public string? AdminName { get; set; }
        
    }
}