using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercerAPI.Dto.Response
{
    public class ProductSingleDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string UrlProduct { get; set; }
        public bool Active { get; set; }
    }
}
