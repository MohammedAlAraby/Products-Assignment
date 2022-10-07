using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Models
{
    public class APIResponse
    {
        public bool Success { get; set; }

        public dynamic Results { get; set; }

        public string[] Messages { get; set; }     
    }    
}
