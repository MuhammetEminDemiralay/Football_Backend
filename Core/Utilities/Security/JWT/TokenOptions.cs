using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    internal class TokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
