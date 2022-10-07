using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Models
{
    public class ProductDto
    {        
        public Guid ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImgURL { get; set; }

        public Guid CateogryID { get; set; }
    }
}
