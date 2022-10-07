using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Entities
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000000000)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 1000000000)]
        public int Quantity { get; set; }

        public string ImgURL { get; set; }

        [ForeignKey("CateogryID")]
        public Category Category { get; set; }

        public Guid CateogryID { get; set; }
    }
}
