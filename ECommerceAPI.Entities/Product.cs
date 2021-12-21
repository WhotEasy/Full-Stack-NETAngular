using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Entities
{
    public class Product :EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        public string CategoryId { get; set; }
        public Category category { get; set; }

        public decimal UnitPrice { get; set; }

        [StringLength(1000)]
        public string Url { get; set; }
        public bool Active { get; set; }

    }
}
