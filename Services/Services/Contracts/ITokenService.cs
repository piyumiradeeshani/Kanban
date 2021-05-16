using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services.Contracts
{
    public interface ITokenService
    {
        public string TokenValidator(string header);
    }
}
