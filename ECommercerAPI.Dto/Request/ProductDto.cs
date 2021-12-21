using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercerAPI.Dto.Request
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public string UrlProduct { get; set; }
        public bool Active { get; set; }
    }
}
