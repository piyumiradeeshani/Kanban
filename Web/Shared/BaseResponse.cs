using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Shared
{
    public class BaseResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
