using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Entities
{
    public class Category
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
