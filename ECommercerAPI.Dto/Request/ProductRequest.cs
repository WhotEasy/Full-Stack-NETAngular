using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercerAPI.Dto.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Active { get; set; }

        //Aqui tiene que ir el binario de la imagen
        public string Base64Image { get; set; }
        public string FileName { get; set; }
    }
}
