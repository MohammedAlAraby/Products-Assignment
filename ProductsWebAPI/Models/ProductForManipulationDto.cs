using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Models
{
    public class ProductForManipulationDto
    {       
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "RequiredName")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "MaxLengthName")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "RequiredPrice")]
        [Range(1, 1000000000, ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "InvalidPrice")]
        public decimal Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "RequiredQuantity")]
        [Range(1, 1000000000, ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "InvalidQuantity")]
        public int Quantity { get; set; }

        public string ImgURL { get; set; }

        public Guid CateogryID { get; set; }
    }
}
