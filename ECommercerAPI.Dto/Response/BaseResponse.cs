using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercerAPI.Dto.Response
{
    public class BaseResponse<TResult>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public TResult result { get; set; }
    }
}
